using System;
using UnityEngine;

namespace Reviva
{
    /*
     * Fairly simple part module which can switch an INTERNAL module on loading a vessel.
     */
    public class IVASwitchPart : PartModule
    {
	[KSPField(isPersistant = true)]
	public string internalName = null;

	public override void OnLoad(ConfigNode node)
	{
            base.OnLoad(node);
	    IVASwitch();
	}

	private void IVASwitch()
	{
            string oldName = GetCurrentInternalName();
            string newName = GetRequiredInternalName();

            Log($"Switch IVA {oldName} -> {newName}");
            if (newName == "")
            {
                Log("internalName is null or empty, no switch");
                return;
            }
	    if (oldName == newName)
            {
                Log("internalName unchanged, no switch");
                return;
            }

            UnloadIVA();
            UpdateInternalConfig(oldName, newName);
            RefreshInternalModel();
            LoadIVA();
        }

        private string GetCurrentInternalName()
        {
	    ConfigNode internalConfig = this.part.partInfo.internalConfig;
	    string name = (internalConfig.HasValue("name")
			   ? internalConfig.GetValue("name")
			   : null);
	    if (name == null)
                name = "";
            return name;
        }

        private string GetRequiredInternalName()
        {
            string name = this.internalName;
	    if (name == null)
                name = "";
            return name;
        }

        private void UnloadIVA()
        {
	    if (!HighLogic.LoadedSceneIsFlight)
                return;

            Log("Unload in-flight IVA");
            this.part.DespawnIVA();
        }

        private void UpdateInternalConfig(string oldName, string newName)
        {
            ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
            newInternalConfig.AddValue("name", newName);
            this.part.partInfo.internalConfig = newInternalConfig;
        }

        private void RefreshInternalModel()
        {
	    if (!HighLogic.LoadedSceneIsFlight)
                return;

            Log("Refresh IVA interal model");
            this.part.CreateInternalModel();
        }

        private void LoadIVA()
        {
	    if (!HighLogic.LoadedSceneIsFlight)
                return;

            Log("Load in-flight IVA");
            this.part.SpawnIVA();
        }

        private void Log(string text)
        {
            Debug.Log($"[Reviva] {text}");
        }
    }
}
