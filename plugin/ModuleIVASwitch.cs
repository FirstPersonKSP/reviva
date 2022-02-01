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
	     * Note this is only done when not in editor. This is fine because the
	     * important piece of information, which internal name to use, is saved with
	     * the vessel. The non-editor game will load the ship and detect a switch is
	     * need first time (or dynamically) and do the right things.
	     */
            base.OnUpdate();
	    if (needUpdate)
                DoIVASwitch();
        }

        /*  -------------------------------------------------------------------------------- */

        private bool needUpdate = false;
        private ConfigNode updateConfig = null;
        private RPMComputer rpmComputer = null;

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

        private void DoIVASwitch()
        {
            needUpdate = false;

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

            Log($"Detected switch IVA {oldName} -> {newName}");
            if (newName == "")
            {
                LogError("internalName is null or empty, no switch");
                return false;
            }
            if (oldName == newName)
            {
                Log("internalName unchanged, no switch");
                return false;
            }
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

            this.rpmComputer.Reboot(this.updateConfig);
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
