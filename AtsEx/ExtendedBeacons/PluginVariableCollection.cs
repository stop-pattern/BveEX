﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnembeddedResources;

using AtsEx.PluginHost.Plugins;

namespace AtsEx.ExtendedBeacons
{
    public sealed class PluginVariableCollection
    {
        private class ResourceSet
        {
            private readonly ResourceLocalizer Localizer = ResourceLocalizer.FromResXOfType<PluginVariableCollection>(@"Core\ExtendedBeacons");

            [ResourceStringHolder(nameof(Localizer))] public Resource<string> PluginIdentifierNotFound { get; private set; }

            public ResourceSet()
            {
                ResourceLoader.LoadAndSetAll(this);
            }
        }

        private static readonly Lazy<ResourceSet> Resources = new Lazy<ResourceSet>();

        static PluginVariableCollection()
        {
#if DEBUG
            _ = Resources.Value;
#endif
        }

        private readonly IEnumerable<string> PluginIdentifiers;
        private readonly PluginType PluginType;

        private readonly Dictionary<string, Dictionary<string, dynamic>> Variables = new Dictionary<string, Dictionary<string, dynamic>>();

        public PluginVariableCollection(IEnumerable<string> pluginIdentifiers, PluginType pluginType)
        {
            PluginIdentifiers = pluginIdentifiers;
            PluginType = pluginType;
        }

        public T GetPluginVariable<T>(string pluginIdentifier, string name) => (T)Variables[pluginIdentifier][name];

        public void SetPluginVariable<T>(string pluginIdentifier, string name, T value)
        {
            if (!Variables.ContainsKey(pluginIdentifier))
            {
                if (!PluginIdentifiers.Contains(pluginIdentifier))
                {
                    throw new KeyNotFoundException(string.Format(Resources.Value.PluginIdentifierNotFound.Value, PluginType.GetTypeString(), pluginIdentifier));
                }

                Variables[pluginIdentifier] = new Dictionary<string, dynamic>();
            }

            Variables[pluginIdentifier][name] = value;
        }
    }
}
