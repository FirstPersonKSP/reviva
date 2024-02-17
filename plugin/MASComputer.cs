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
            // If there is no MASFlightComputer data, the default is empty unless RPM is also
            // present in which case the best option is more likely some reasonable defaults
            // copied from AvionicsSystems/GameData/MOARdV/Patches/JsiToMasUpgrade.cfg
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
                }");
        }

        // MASFlightComputer does not use OnLoad() to get PERSISTENT_VARIABLES,
        // RPM_COLOROVERRIDE, or MAS_ACTION_GROUP.  These have to be updated in the
        // part.partInfo - which is sort of sketchy, but essentially Reviva is taking
        // control of INTERNAL anyway, so now also MASFlightComputer config.
        protected override void RecreateComputerPreAddHook(Part ownerPart, ConfigNode newConfig)
        {
            base.RecreateComputerPreAddHook(ownerPart, newConfig);

            // Find the existing FlightComputer in partInfo and change it to the new one.
            ConfigNode[] oldComputerNodes = ownerPart.partInfo.partConfig.GetNodes("MODULE", "name", this.ModuleName);
            foreach (ConfigNode oldComputerNode in oldComputerNodes)
            {
#if REVIVA_DEBUG
                Log($"Removing: {oldComputerNode}");
#endif
                ownerPart.partInfo.partConfig.RemoveNode(oldComputerNode);
            }

            ConfigNode newComputerNode = new ConfigNode("MODULE");
            newConfig.CopyTo(newComputerNode);

#if REVIVA_DEBUG
        Log($"Adding: {newComputerNode}");
#endif
            ownerPart.partInfo.partConfig.AddNode(newComputerNode);
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
