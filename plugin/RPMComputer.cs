using System;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Reviva
{
    public class RPMComputer : BaseComputer
    {
        public RPMComputer(ModuleIVASwitch ivaSwitch)
            : base(ivaSwitch)
        {
        }

        public override bool IsEnabled => rpmEnabled;
        public override string ModuleName => "RasterPropMonitorComputer";

        /* ------------------------------------------------------------------------------- */

        protected override ConfigNode CreateDefaultData()
        {
            return new ConfigNode();
        }

        /* ------------------------------------------------------------------------------- */
        private static readonly bool rpmEnabled;
        private static readonly string rpmAssembly = "RasterPropMonitor";

        static RPMComputer()
        {
            rpmEnabled = BaseComputer.DetectAssembly(rpmAssembly);
        }
    }
}
