using System;
using UnityEngine;

namespace Reviva
{
	// Fairly simple part module which can switch an INTERNAL module on loading a vessel.
	public class ModuleIVASwitch : PartModule
	{
		[KSPField(isPersistant = true)]
		public string internalName = null;

		public override void OnLoad(ConfigNode node)
		{
			base.OnLoad(node);

			if (!HighLogic.LoadedSceneIsFlight) return;
			
			if (!vessel.loaded)
			{
				UpdateInternalConfig(internalName);
				return;
			}

			// In order to reduce switching, detect if a change has been requested for each
			// load over one frame (this may be undone, or multiple loads may happen).
			//  
			// The actual update is done from OnUpdate() which means the IVA can be updated
			// over one or more frames (if required in the future).  
			needUpdate = HasInternalNameChanged();
			updateConfig = needUpdate ? node : null;

			// To support QuickIVA and for sanity, if loading vessel before flight scene
			// is ready, can do the internal configuration update which will cause the
			// right IVA to be loaded when QuickIVA goes direct to IVA.
			if (needUpdate && this.vessel != null)
			{
				Log($"Trying to switch IVA to for newly loaded vessel");
				if (CanIVASwitch())
				{
					string newName = GetRequiredInternalName();
					Log($"Switching IVA to {newName} before vessel loads (for QuickIVA support)");
					DoIVASwitch();
				}
			}
		}

		public override void OnUpdate()
		{
			// Detect1VASwitch() is called when loading the ModuleIVASwitch, which happens
			// in several scenarios:
			// 
			// - When the vessel is loaded, and so all the part modules are loaded.
			// - When the module is modified by B9PartSwitch itself.
			// 
			// needUpdate: Has change has been detected?
			// 		If true, should switch IVA when possible, additionally updateConfig is set to
			// 		the ModuleIVASwitch config node.
			// 
			base.OnUpdate();
			if (needUpdate && CanIVASwitch())
			{
				DoIVASwitch();
			}
		}

		public RPMComputer RPMComputer => this.rpmComputer;
		public MASComputer MASComputer => this.masComputer;

		/*  -------------------------------------------------------------------------------- */

		private bool needUpdate = false;
		private ConfigNode updateConfig = null;
		private RPMComputer rpmComputer = null;
		private MASComputer masComputer = null;

		private bool CanIVASwitch()
		{
			bool canUpdate = true;

			// Disallow switching IVA if in the active vessel, and viewing the IVA.
			// 
			// Logic here is based on ideas from AvionicsSystem:
			// - https://github.com/MOARdV/AvionicsSystems
			//   Source/MASVesselComputer.cs - ActiveVessel()
			if (this.vessel != null && this.vessel.isActiveVessel)
			{
				var mode = CameraManager.Instance.currentCameraMode;
				if (mode == CameraManager.CameraMode.IVA || mode == CameraManager.CameraMode.Internal)
				{
#if REVIVA_DEBUG
					Log($"Defer switch IVA, active vessel IVA in view");
#endif
					canUpdate = false;
				}
			}

			return canUpdate;
		}

		private void DoIVASwitch()
		{
			if (!HighLogic.LoadedSceneIsFlight) return;

			needUpdate = false;

			string oldName = GetCurrentInternalConfigName();
			string newName = GetRequiredInternalName();
			Log($"Switching IVA to {newName}");
#if REVIVA_DEBUG
			Log($"updateConfig={updateConfig}");
#endif

			this.part.DespawnIVA();

			UpdateInternalConfig(newName);

			RebootRPMComputer();

			//this.part.SpawnIVA();

			// the following is essentially what SpawnIVA does, except SpawnIVA is a no-op if the part has no crew capacity
			// FreeIVA includes several internal models that do not have crew capacity, and failing to call internalModel.Initialize() will leave the internal model attached to the part and make physics go insane

			if (this.part.internalModel == null)
			{
				this.part.CreateInternalModel();
			}

			if (this.part.internalModel != null)
			{
				this.part.internalModel.Initialize(this.part);
				this.part.internalModel.SpawnCrew();
				this.part.internalModel.SetVisible(false);
			}
		}

		private bool HasInternalNameChanged()
		{
			string oldConfigName = GetCurrentInternalConfigName();
			string oldModelName = this.part?.internalModel?.internalName;
			string newName = GetRequiredInternalName();

			Log($"HasInternalNameChanged: oldConfigName={oldConfigName} oldModelName={oldModelName} newName={newName}");
			if (newName == "")
			{
				LogError("InternalName is null or empty, no switch");
				return false;
			}

			// If oldModelName is non-null, then use this to check differences as that is
			// the currently loaded in-flight dynamic IVA name.
			if (oldModelName != null)
			{
				if (oldModelName != newName)
				{
					Log($"InternalModel switch IVA {oldModelName} -> {newName}");
					return true;
				}

				Log("InternalModel unchanged, no in-flight dynamic IVA switch needed");
				return false;
			}

			// Otherwise the use the partInfo name.
			if (oldConfigName != newName)
			{
				Log($"InternalConfig switch IVA {oldConfigName} -> {newName}");
				return true;
			}

			Log("InternalConfig unchanged, no IVA switch needed");
			return false;
		}

		// Name of the part's partInfo internalConfig, used to spawn correct IVA
		private string GetCurrentInternalConfigName()
		{
			ConfigNode internalConfig = this.part?.partInfo?.internalConfig;
			return internalConfig?.GetValue("name") ?? "";
		}

		private string GetRequiredInternalName()
		{
			return this.internalName ?? "";
		}

		private void UpdateInternalConfig(string newName)
		{
			ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
			newInternalConfig.AddValue("name", newName);
			this.part.partInfo = new AvailablePart(this.part.partInfo); // clone the partinfo so we don't affect all instances of this part
			this.part.partInfo.internalConfig = newInternalConfig;
		}

		private void RebootRPMComputer()
		{
			if (this.rpmComputer == null)
				this.rpmComputer = new RPMComputer(this);
			if (this.masComputer == null)
				this.masComputer = new MASComputer(this);

			this.rpmComputer.Reboot(this.updateConfig);
			this.masComputer.Reboot(this.updateConfig);
		}

		private void Log(string text)
		{
			Debug.Log($"[Reviva] {text}");
		}

		private void LogError(string text)
		{
			Debug.LogError($"[Reviva] {text}");
		}
	}
}
