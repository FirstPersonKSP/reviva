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
        protected override string ModuleName => "RasterPropMonitorComputer";

        /* ------------------------------------------------------------------------------- */
        private static readonly bool rpmEnabled;
        private static readonly string rpmAssembly = "RasterPropMonitor";

        static RPMComputer()
        {
            rpmEnabled = BaseComputer.DetectAssembly(rpmAssembly);
        }
    }
}
