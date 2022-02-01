using System;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Reviva
{
    public class RPMComputer : object
    {
        public static string AssemblyName = "RasterPropMonitor";
        public static string ModuleName = "RasterPropMonitorComputer";

	public RPMComputer(ModuleIVASwitch ivaSwitch)
	{
            this.ivaSwitch = ivaSwitch;
            this.part = this.ivaSwitch?.part;
            this.rpmComputer = null;
            this.rpmComputerData = null;
            this.rpmComputerConfig = null;
            Log($"Created {ModuleName} proxy for ModuleIVASwitch");
        }

        public ModuleIVASwitch ivaSwitch;
        public Part part;
        public PartModule rpmComputer;
        public ConfigNode rpmComputerData; // ConfigNode in updateConfig
        public ConfigNode rpmComputerConfig; // Duplicated MODULE ConfigNode for RPM computer

        public void Reboot(ConfigNode updateConfig)
        {
	    if (!rpmEnabled)
                return;

            if (updateConfig == null)
            {
                LogError("No updateConfig present, cannot reboot RPM computer");
                return;
            }

            if (!ValidateRPMComputer())
                return;

            FindRPMComputerData(updateConfig);
            BuildNewConfig();
            RecreateRPMComputer();
        }

        /* ------------------------------------------------------------------------------- */
        private static readonly bool rpmEnabled;

        static RPMComputer()
        {
            var rpmAssembly = AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == AssemblyName);
            rpmEnabled = (rpmAssembly != null);

            Log($"Detected {AssemblyName}: {rpmEnabled}");
        }

        /* -------------------------------------------------------------------------------- */

        private bool ValidateRPMComputer()
        {
            if (this.ivaSwitch == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch");
                return false;
            }
            if (this.part == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part");
                return false;
            }
            if (this.part.partInfo == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part.partInfo");
                return false;
            }
            if (this.part.partInfo.partConfig == null)
            {
                LogError($"{ModuleName} has null ModuleIVASwitch part.partInfo.partConfig");
                return false;
            }

	    this.rpmComputer = this.part.Modules?.GetModule(ModuleName);
            if (this.rpmComputer == null)
	    {
                Log($"No {ModuleName} found, strange but not impossible, adding one");
		// This is ok, will create new one
            }

            return true;
        }

        private void FindRPMComputerData(ConfigNode updateConfig)
        {
            this.rpmComputerData = updateConfig.GetNode(RPMComputer.ModuleName);
            if (this.rpmComputerData == null)
            {
                /* 
                 * This means the subtype is not configured, usually stock or does not need
                 * RPM computer. Assume nothing is needed.
                 */
                Log($"No {RPMComputer.ModuleName} ConfigNode in B9PartSwitch MODULE DATA: assume empty");
                this.rpmComputerData = new ConfigNode();
            }
        }

        private void BuildNewConfig()
        {
            this.rpmComputerConfig = new ConfigNode("MODULE");
            this.rpmComputerConfig.AddValue("name", ModuleName);
            this.rpmComputerData.CopyTo(this.rpmComputerConfig);
        }

        private void RecreateRPMComputer()
        {
            ConfigNode oldConfig = FindModuleConfig(this.rpmComputer) ?? new ConfigNode();
            ConfigNode newConfig = this.rpmComputerConfig;

            Log($"Rebooting {ModuleName} with changed configuration");
            Log($"OldConfig: {oldConfig}");
            Log($"NewConifg: {newConfig}");

            int index = -1;
            if (this.rpmComputer != null)
            {
                index = DestroyModule(this.rpmComputer);
            }
            AddModuleAt(index, newConfig);
        }

        private ConfigNode FindModuleConfig(PartModule module)
        {
            ConfigNode[] modules = this.part.partInfo.partConfig.GetNodes("MODULE");
            if (modules == null)
                return null;
            foreach (ConfigNode m in modules)
	    {
                if (m.GetValue("name") == module.moduleName)
                    return m;
            }
            return null;
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

        private static void Log(string text)
        {
            Debug.Log($"[Reviva] {text}");
        }

        private static void LogError(string text)
        {
            Debug.LogError($"[Reviva] {text}");
        }
    }
}
