﻿using Automatic9045.AtsEx.PluginHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Automatic9045.AtsEx.Plugins.Scripting;
using Automatic9045.AtsEx.PluginHost.ExtendedBeacons;
using Automatic9045.AtsEx.PluginHost.Plugins;

namespace Automatic9045.AtsEx.ExtendedBeacons
{
    public abstract class ExtendedBeaconGlobalsBase<TPassedEventArgs> : Globals where TPassedEventArgs : PassedEventArgs
    {
#pragma warning disable IDE1006 // 命名スタイル
        public readonly PluginHost.ExtendedBeacons.ExtendedBeaconBase<TPassedEventArgs> sender;
        public readonly TPassedEventArgs e;
#pragma warning restore IDE1006 // 命名スタイル

        private protected readonly IReadOnlyDictionary<PluginType, PluginVariableCollection> PluginVariables;

        public ExtendedBeaconGlobalsBase(PluginHost.BveHacker bveHacker, IReadOnlyDictionary<PluginType, PluginVariableCollection> pluginVariables,
            PluginHost.ExtendedBeacons.ExtendedBeaconBase<TPassedEventArgs> sender, TPassedEventArgs eventArgs)
            : base(bveHacker)
        {
            PluginVariables = pluginVariables;

            this.sender = sender;
            e = eventArgs;
        }

        public T GetPluginVariable<T>(PluginType pluginType, string pluginIdentifier, string name)
            => PluginVariables[pluginType].GetPluginVariable<T>(pluginIdentifier, name);

        public void SetPluginVariable<T>(PluginType pluginType, string pluginIdentifier, string name, T value)
            => PluginVariables[pluginType].SetPluginVariable(pluginIdentifier, name, value);

        internal abstract TPassedEventArgs GetEventArgsWithScriptVariables();
    }
}