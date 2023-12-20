﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

using UnembeddedResources;

namespace TypeWrapping
{
    public partial class WrapTypeSet
    {
        private class ResourceSet
        {
            private readonly ResourceLocalizer Localizer = ResourceLocalizer.FromResXOfType(typeof(WrapTypeSet), @"TypeWrapping\WrapTypeSet");

            [ResourceStringHolder(nameof(Localizer))] public Resource<string> XmlSchemaValidation { get; private set; }

            public ResourceSet()
            {
                ResourceLoader.LoadAndSetAll(this);
            }
        }

        private static readonly Lazy<ResourceSet> Resources = new Lazy<ResourceSet>();

        static WrapTypeSet()
        {
#if DEBUG
            _ = Resources.Value;
#endif
        }

        public IEnumerable<TypeMemberSetBase> Types { get; }
        public TypeBridge Bridge { get; }

        private WrapTypeSet(IEnumerable<TypeMemberSetBase> types, TypeBridge bridge)
        {
            Types = types;
            Bridge = bridge;
        }

        public static WrapTypeSet LoadXml(Stream docStream, Stream schemaStream,
            IEnumerable<Type> wrapperTypes, IEnumerable<Type> originalTypes, IDictionary<Type, Type> additionalWrapperToOriginal)
        {
            XDocument doc = XDocument.Load(docStream);

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchema schema = XmlSchema.Read(schemaStream, SchemaValidation);
            schemaSet.Add(schema);
            doc.Validate(schemaSet, DocumentValidation);

            TypeParser wrapperTypeParser = new TypeParser("atsex", wrapperTypes);
            TypeParser originalTypeParser = new TypeParser("bve", originalTypes);

            string targetNamespace = $"{{{schema.TargetNamespace}}}";

            XElement root = doc.Element(targetNamespace + "WrapTypes");
            MemberLoader loader = new MemberLoader(root, targetNamespace, wrapperTypeParser, originalTypeParser, additionalWrapperToOriginal);
            loader.LoadAll();

            return new WrapTypeSet(loader.Types, loader.Bridge);
        }

        private static void SchemaValidation(object sender, ValidationEventArgs e)
        {
            throw new FormatException(Resources.Value.XmlSchemaValidation.Value, e.Exception);
        }

        private static void DocumentValidation(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }
    }
}