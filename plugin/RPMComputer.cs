using System;
using UnityEngine;

namespace Reviva
{
    
    public class RPMComputer : object
    {
	public static string ModuleName = "RasterPropMonitorComputer";

	public RPMComputer(ModuleIVASwitch ivaSwitch)
	{
            this.ivaSwitch = ivaSwitch;
            this.part = this.ivaSwitch?.part;
            this.rpmComputer = null;
            Log($"Created {ModuleName} proxy for ModuleIVASwitch");
        }

        public ModuleIVASwitch ivaSwitch;
        public Part part;
        public PartModule rpmComputer;

        public void Reboot(ConfigNode moduleData)
        {
            if (this.ivaSwitch == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch");
                return;
            }
            if (this.part == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part");
                return;
            }
            if (this.part.partInfo == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part.partInfo");
                return;
            }
            if (this.part.partInfo.partConfig == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part.partInfo.partConfig");
                return;
            }

	    this.rpmComputer = this.part.Modules?.GetModule(ModuleName);
            if (this.rpmComputer == null)
	    {
                Log($"No {ModuleName} found, strange but not impossible, adding one");
                return;
            }

            ConfigNode newConfig = new ConfigNode("MODULE");
            newConfig.AddValue("name", ModuleName);
            moduleData.CopyTo(newConfig);

            int index = -1;
            if (this.rpmComputer != null)
            {
                ChangeModuleConfig(this.rpmComputer, newConfig);
                index = DestroyModule(this.rpmComputer);
            }
            AddModuleAt(index, newConfig);
        }

        /*  -------------------------------------------------------------------------------- */

        private ConfigNode FindModuleConfig(PartModule module)
        {
            ConfigNode[] modules = this.part.partInfo.partConfig.GetNodes("MODULE");
            if (modules == null)
            {
                LogError($"Cannot find {module.moduleName} ConfigNode, part or partConfig null");
                return null;
            }
            foreach (ConfigNode m in modules)
	    {
                if (m.GetValue("name") == module.moduleName)
                    return m;
            }

	    LogError($"Cannot find {module.moduleName} ConfigNode, module not in partConfig");
            return null;
        }

        private void ChangeModuleConfig(PartModule module, ConfigNode newConfig)
        {
            ConfigNode oldConfig = FindModuleConfig(module) ?? new ConfigNode();

            Log($"Updating {module.moduleName} configuration");
            Log($"OldConfig: {oldConfig}");
            Log($"NewConifg: {newConfig}");

	    // Nothing needed here, the RPM computer is reloaded with the new data.
        }

        private int DestroyModule(PartModule module)
        {
            int index = this.part.Modules.IndexOf(module);
            if (index < 0)
            {
                LogError($"Cannot find {module.moduleName} in partConfig");
                return -1;
            }

            Log($"Destroying {module.moduleName} at index {index}");
            this.part.Modules[index] = null;
            UnityEngine.Object.DestroyImmediate((UnityEngine.Object)module);
            return index;
        }

        private void AddModuleAt(int index, ConfigNode newConfig)
        {
            string moduleName = newConfig.GetValue("name");
            if (moduleName == null)
            {
                LogError("Cannot create new module, no name entry in ConfigNode");
                return;
            }

            Log($"Adding new {moduleName}");
            PartModule newModule = this.part.AddModule(newConfig, /*forceAwake=*/true);
            if (newModule == null)
            {
                LogError($"Cannot create new {moduleName}");
                return;
            }

            /*
	     * If PartModule index stability is required (replacing old one), then
	     * AddModule() just appended to PartModuleList, remove it (note PartModuleList.Remove vs
	     * Part.RemoveModule) and set the index.
	     */
            if (index >= 0)
            {
                Log($"Ensure {moduleName} is at index {index}");
                this.part.Modules.Remove(newModule);
                this.part.Modules[index] = newModule;
            }
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
