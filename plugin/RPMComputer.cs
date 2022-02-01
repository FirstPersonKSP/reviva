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

        /* ------------------------------------------------------------------------------- */

        protected override bool IsEnabled => rpmEnabled;
        protected override string ModuleName => "RasterPropMonitor";

        /* ------------------------------------------------------------------------------- */
        private static readonly bool rpmEnabled;
        private static readonly string rpmAssembly = "RasterPropMonitorComputer";

        static RPMComputer()
        {
            rpmEnabled = BaseComputer.DetectAssembly(rpmAssembly);
        }
    }
}
