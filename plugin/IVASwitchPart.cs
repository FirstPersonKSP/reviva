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

            Debug.Log($"IVASwitch: {oldName} -> {newName}");
            if (newName == "")
            {
                Debug.Log("IVASwitch: internalName is null or empty, no switch");
                return;
            }
	    if (oldName == newName)
            {
                Debug.Log("IVASwitch: internalName unchanged, no switch");
                return;
            }
    
	    ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
	    newInternalConfig.AddValue("name", newName);
	    this.part.partInfo.internalConfig = newInternalConfig;
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
    }
}
