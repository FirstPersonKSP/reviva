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
	public string InternalName = null;

	public override void OnLoad(ConfigNode node)
	{
	    base.OnLoad(node);
	    IVASwitch();
	}

	private void IVASwitch()
	{
	    if (string.IsNullOrEmpty(InternalName))
		return;

	    ConfigNode oldInternalConfig = part.partInfo.internalConfig;
	    string oldName = oldInternalConfig.HasValue("name") ? oldInternalConfig.GetValue("name") : "";

	    Debug.Log(string.Format("IVASwitch: {} -> {}", oldName, InternalName));

	    ConfigNode newInternalConfig = new ConfigNode("INTERNAL");
	    newInternalConfig.AddValue("name", InternalName);
	    part.partInfo.internalConfig = newInternalConfig;
	}
    }
}
