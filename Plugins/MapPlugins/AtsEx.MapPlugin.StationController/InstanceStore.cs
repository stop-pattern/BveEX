﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Automatic9045.AtsEx.PluginHost;

namespace Automatic9045.MapPlugins.StationController
{
    internal sealed class InstanceStore
    {
        private static InstanceStore _Instance = null;
        public static InstanceStore Instance => _Instance;
        public static bool IsInitialized => !(_Instance is null);

        public static void Initialize(IApp app, IBveHacker bveHacker)
        {
            _Instance = new InstanceStore(app, bveHacker);
        }


        public IApp App { get; }
        public IBveHacker BveHacker { get; }

        private InstanceStore(IApp app, IBveHacker bveHacker)
        {
            App = app;
            BveHacker = bveHacker;
        }
    }
}
