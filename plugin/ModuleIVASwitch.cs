using System;
using UnityEngine;

namespace Reviva
{
    /*
     * Fairly simple part module which can switch an INTERNAL module on loading a vessel.
     */
    public class ModuleIVASwitch : PartModule
    {
        [KSPField(isPersistant = true)]
        public string internalName = null;

        public override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
            DetectIVASwitch(node);
        }

        public override void OnUpdate()
        {
	    /*
	     * DetectIVASwitch() is called when loading the ModuleIVASwitch, which happens
	     * in several scenarios:
	     * 
	     * - When the vessel is loaded, and so all the part modules are loaded.
	     * - When the module is modified by B9PartSwitch itself.
	     * 
	     * needUpdate: Has change has been detected?
	     *		If true, should switch IVA when possible, additionally updateConfig is set to
	     *		the ModuleIVASwitch config node.
	     * 
	     * canUpdate: Can change be made in this frame?
	     *		If true, changing the IVA is safe to do.
	     *		If false, not currently possible (currently in the IVA that is switching for
	     *		example), the actual update is deferred until this becomes true
	     *		(or needUpdate becomes false).
	     */
            base.OnUpdate();
	    if (needUpdate)
		CanIVASwitch();
            if (needUpdate && canUpdate)
                DoIVASwitch();
        }

        public RPMComputer RPMComputer => this.rpmComputer;
        public MASComputer MASComputer => this.masComputer;

        /*  -------------------------------------------------------------------------------- */

        private bool needUpdate = false;
        private bool canUpdate = false;
        private ConfigNode updateConfig = null;
        private RPMComputer rpmComputer = null;
        private MASComputer masComputer = null;

        private void DetectIVASwitch(ConfigNode node)
        {
	    /*
	     * In order to reduce switching, detect if a change has been requested for each
	     * load over one frame (this may be undone, or multiple loads may happen).
	     * 
	     * The actual update is done from OnUpdate() which means the IVA can be updated
	     * over one or more frames (if required in the future).
	     */
            needUpdate = HasInternalNameChanged();
            updateConfig = needUpdate ? node : null;
        }

        private void CanIVASwitch()
        {
            canUpdate = true;

            /*
             * Disallow switching IVA if in the active vessel, and viewing the IVA.
	     * 
	     * Logic here is based on ideas from AvionicsSystem:
	     * - https://github.com/MOARdV/AvionicsSystems
	     *   Source/MASVesselComputer.cs - ActiveVessel()
             */
            if (this.vessel.isActiveVessel)
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
        }

        private void DoIVASwitch()
        {
            needUpdate = false;
            canUpdate = false;

            string oldName = GetCurrentInternalName();
            string newName = GetRequiredInternalName();

            if (oldName == newName || newName == "")
            {
                LogError($"Internal model unchanged oldName={oldName} newName={newName}");
                return;
            }

            Log($"Executing switch IVA {oldName} -> {newName}");

            UnloadIVA();
            UpdateInternalConfig(newName);
            RebootRPMComputer();
            RefreshInternalModel();
            LoadIVA();
        }

        private bool HasInternalNameChanged()
        {
            string oldName = GetCurrentInternalName();
            string newName = GetRequiredInternalName();

#if REVIVA_DEBUG
            Log($"Detecting switch IVA {oldName} -> {newName}");
#endif
            if (newName == "")
            {
#if REVIVA_DEBUG
                LogError("internalName is null or empty, no switch");
#endif
                return false;
            }
            if (oldName == newName)
            {
#if REVIVA_DEBUG
                Log("internalName unchanged, no switch");
#endif
                return false;
            }

            Log($"Detected switch IVA {oldName} -> {newName}");
            return true;
        }

	private string GetCurrentInternalName()
        {
            ConfigNode internalConfig = this.part?.partInfo?.internalConfig;
            return GetConfigValue(internalConfig, "name");
        }

        private string GetConfigValue(ConfigNode node, string id)
        {
            if (node == null || !node.HasValue(id))
                return "";
            return node.GetValue(id) ?? "";
        }

        private string GetRequiredInternalName()
        {
            return this.internalName ?? "";
        }

        private void UnloadIVA()
        {
            if (!HighLogic.LoadedSceneIsFlight)
            {
                Log("Not in flight scene, IVA not unloaded");
                return;
            }

            Log("Unload in-flight IVA");
            this.part.DespawnIVA();
        }

        private void UpdateInternalConfig(string newName)
        {
            if (this.part?.partInfo == null)
            {
                LogError("No part or partinfo, cannot switch");
                return;
            }

            ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
            newInternalConfig.AddValue("name", newName);
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

        private void RefreshInternalModel()
        {
            if (!HighLogic.LoadedSceneIsFlight)
            {
                Log("Not in flight scene, internal model not refreshed");
                return;
            }
            if (this.part == null)
            {
                LogError("No current part, internal model not refreshed");
                return;
            }

            Log("Refresh IVA interal model");
            this.part.CreateInternalModel();
        }

        private void LoadIVA()
        {
            if (!HighLogic.LoadedSceneIsFlight)
            {
                Log("Not in flight scene, IVA not loaded");
                return;
            }

            Log("Load in-flight IVA");
            this.part.SpawnIVA();
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
