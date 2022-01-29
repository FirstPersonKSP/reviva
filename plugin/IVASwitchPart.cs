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
            string newName = (internalName != null ? internalName : "null");
            Debug.Log("IVASwitch: internalName=" + newName);

            base.OnLoad(node);
	    IVASwitch();
	}

	private void IVASwitch()
	{
	    if (string.IsNullOrEmpty(internalName))
		return;

	    ConfigNode oldInternalConfig = part.partInfo.internalConfig;
	    string oldName = (oldInternalConfig.HasValue("name")
			      ? oldInternalConfig.GetValue("name")
			      : null);
	    if (string.IsNullOrEmpty(oldName))
                oldName = "null";

            Debug.Log("IVASwitch: " + oldName + " -> " + internalName);

	    ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
	    newInternalConfig.AddValue("name", internalName);
	    part.partInfo.internalConfig = newInternalConfig;
	}
    }
}
