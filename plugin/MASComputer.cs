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

        public override bool IsEnabled => masEnabled;

        public override string ModuleName => "MASFlightComputer";

        /* ------------------------------------------------------------------------------- */

        protected override ConfigNode CreateDefaultData()
        {
	    if (!this.ModuleIVASwitch.RPMComputer.IsEnabled)
                return new ConfigNode();

            /*
	     * If there is no MASFlightComputer data, the default is empty unless RPM is also
	     * present in which case the best option is more likely some reasonable defaults
	     * copied from AvionicsSystems/GameData/MOARdV/Patches/JsiToMasUpgrade.cfg
	     */
            return ConfigNode.Parse(@"
		requiresPower = true
		gLimit = 4.7
		baseDisruptionChance = 0.20
		// stored strings are part of the ALCOR lander pod, but they may be referenced elsewhere.
		PERSISTENT_VARIABLES
		{
			storedStrings0=v 0.9.7.0
			storedStrings1=08.07.2020
			storedStrings2=A.L.C.O.R.
			storedStrings3=ADVANCED LANDING CAPSULE
			storedStrings4=FOR    ORBITAL    RENDEZVOUS
			storedStrings5=ALC00236-A3
			storedStrings6=ALCOR
			storedStrings7=A.S.E.T.
		}
");
        }

        /* ------------------------------------------------------------------------------- */
        private static readonly bool masEnabled;
        private static readonly string masAssembly = "AvionicsSystems";

        static MASComputer()
        {
            masEnabled = BaseComputer.DetectAssembly(masAssembly);
        }
    }
}
