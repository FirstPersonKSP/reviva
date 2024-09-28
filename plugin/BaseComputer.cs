using System;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Reviva
{
    public abstract class BaseComputer : object
    {
        public void Reboot(ConfigNode updateConfig)
        {
            if (!this.IsEnabled)
                return;

            if (updateConfig == null)
            {
                LogError($"No updateConfig present, cannot reboot {ModuleName}");
                return;
            }

            if (!ValidateComputer())
                return;

            FindComputerData(updateConfig);
            BuildNewConfig();
            RecreateComputer();
        }

        public ModuleIVASwitch ModuleIVASwitch => this.ivaSwitch;

        public abstract bool IsEnabled
        {
            get;
        }

        public abstract string ModuleName
        {
            get;
        }

        /* -------------------------------------------------------------------------------- */

        protected BaseComputer(ModuleIVASwitch ivaSwitch)
        {
            this.ivaSwitch = ivaSwitch;
            this.part = this.ivaSwitch?.part;
            this.computer = null;
            this.computerData = null;
            this.computerConfig = null;
            Log($"Created {ModuleName} proxy for ModuleIVASwitch");
        }

        protected abstract ConfigNode CreateDefaultData();

        protected static bool DetectAssembly(string assemblyName)
        {
            var assembly = AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == assemblyName);
            bool enabled = (assembly != null);
            Log($"Detected {assemblyName}: {enabled}");
            return enabled;
        }

        /* -------------------------------------------------------------------------------- */

        private ModuleIVASwitch ivaSwitch;
        private Part part;
        private PartModule computer;
        private ConfigNode computerData; // ConfigNode in updateConfig
        private ConfigNode computerConfig; // Duplicated MODULE ConfigNode for computer

        /* -------------------------------------------------------------------------------- */

        private bool ValidateComputer()
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

            this.computer = this.part.Modules?.GetModule(ModuleName);
            if (this.computer == null)
            {
                Log($"No {ModuleName} found, strange but not impossible, adding one");
                // This is ok, will create new one
            }

            return true;
        }

        private void FindComputerData(ConfigNode updateConfig)
        {
            this.computerData = updateConfig.GetNode(this.ModuleName);
            if (this.computerData == null)
            {
                // This means the subtype is not configured, usually stock or does not need
                // RPM computer. Assume nothing is needed.
                Log($"No {ModuleName} ConfigNode in B9PartSwitch MODULE DATA: assume default");
                this.computerData = CreateDefaultData();
            }
        }

        private void BuildNewConfig()
        {
            this.computerConfig = new ConfigNode("MODULE");
            this.computerConfig.AddValue("name", ModuleName);
            this.computerData.CopyTo(this.computerConfig);
        }

        protected virtual void RecreateComputerPreAddHook(Part ownerPart, ConfigNode newConfig)
        {
            // Sub-classes may hook here to do something before the Computer is added back.
        }

        private void RecreateComputer()
        {
            ConfigNode oldConfig = FindModuleConfig(this.computer) ?? new ConfigNode();
            ConfigNode newConfig = this.computerConfig;

            Log($"Rebooting {ModuleName} with changed configuration");
#if REVIVA_DEBUG
            Log($"OldConfig: {oldConfig}");
            Log($"NewConifg: {newConfig}");
#endif

            int index = -1;
            if (this.computer != null)
            {
                index = DestroyModule(this.computer);
            }

            // Sub-classes may need to do more with the config: MAS needs to update partInfo.
            RecreateComputerPreAddHook(this.part, newConfig);

            AddModuleAt(index, newConfig);
        }

        private ConfigNode FindModuleConfig(PartModule module)
        {
            if (module == null)
                return null;
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
            PartModule newModule = this.part.AddModule(newConfig, forceAwake : true);
            if (newModule == null)
            {
                LogError($"Cannot create new {moduleName}");
                return;
            }

            // If PartModule index stability is required (replacing old one), then
            // AddModule() just appended to PartModuleList, remove it (note PartModuleList.Remove vs
            // Part.RemoveModule) and set the index.
            if (index >= 0)
            {
                Log($"Ensure {moduleName} is at index {index}");
                this.part.Modules.Remove(newModule);
                this.part.Modules[index] = newModule;
            }
        }

        protected static void Log(string text)
        {
            Debug.Log($"[Reviva] {text}");
        }

        protected static void LogError(string text)
        {
            Debug.LogError($"[Reviva] {text}");
        }
    }
}
