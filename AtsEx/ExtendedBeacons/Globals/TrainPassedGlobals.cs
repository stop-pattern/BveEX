﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtsEx.PluginHost;
using AtsEx.PluginHost.ExtendedBeacons;
using AtsEx.PluginHost.Plugins;

namespace AtsEx.ExtendedBeacons
{
    internal class TrainPassedGlobals : ExtendedBeaconGlobalsBase<TrainPassedEventArgs>
    {
        public TrainPassedGlobals(IScenarioService scenarioService, PluginHost.BveHacker bveHacker,
            PluginHost.ExtendedBeacons.ExtendedBeaconBase<TrainPassedEventArgs> sender, TrainPassedEventArgs eventArgs)
            : base(scenarioService, bveHacker, sender, eventArgs)
        {
        }

        internal override TrainPassedEventArgs GetEventArgsWithScriptVariables() => new TrainPassedEventArgs(e, Variables);
    }
}
