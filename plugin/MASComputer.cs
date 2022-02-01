using System;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Reviva
{
    public class MASComputer : BaseComputer
    {
        public MASComputer(ModuleIVASwitch ivaSwitch)
            : base(ivaSwitch)
        {
        }

        /* ------------------------------------------------------------------------------- */

        protected override bool IsEnabled => masEnabled;
        protected override string ModuleName => "MASFlightComputer";

        /* ------------------------------------------------------------------------------- */
        private static readonly bool masEnabled;
        private static readonly string masAssembly = "AvionicsSystems";

        static MASComputer()
        {
            masEnabled = BaseComputer.DetectAssembly(masAssembly);
        }
    }
}
