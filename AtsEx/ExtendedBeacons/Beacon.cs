﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BveTypes.ClassWrappers;

using AtsEx.PluginHost;
using AtsEx.PluginHost.ExtendedBeacons;
using AtsEx.Scripting;

namespace AtsEx.ExtendedBeacons
{
    internal class Beacon : ExtendedBeaconBase<PassedEventArgs>
    {
        private double OldLocation = 0d;

        public Beacon(NativeImpl native, BveHacker bveHacker,
            string name, RepeatedStructure definedStructure, ObservingTargetTrack observingTargetTrack, ObservingTargetTrain observingTargetTrain,
            IPluginScript<ExtendedBeaconGlobalsBase<PassedEventArgs>> script)
            : base(native, bveHacker, name, definedStructure, observingTargetTrack, observingTargetTrain, script)
        {
        }

        internal virtual void Tick(double currentLocation)
        {
            if (OldLocation < Location && Location <= currentLocation)
            {
                NotifyPassed(Direction.Forward);
            }
            else if (Location < OldLocation && currentLocation <= Location)
            {
                NotifyPassed(Direction.Backward);
            }

            OldLocation = currentLocation;
        }

        protected void NotifyPassed(Direction direction)
        {
            PassedEventArgs eventArgs = new PassedEventArgs(direction);
            PassedGlobals globals = new PassedGlobals(Native, BveHacker, this, eventArgs);
            Script.Run(globals);
            base.NotifyPassed(globals.GetEventArgsWithScriptVariables());
        }
    }
}
