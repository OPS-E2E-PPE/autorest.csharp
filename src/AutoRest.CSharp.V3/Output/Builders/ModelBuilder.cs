﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ModelBuilder
    {
        private readonly KnownMediaType[] _mediaTypes;

        public ModelBuilder(KnownMediaType[] mediaTypes)
        {
            _mediaTypes = mediaTypes;
        }

        private static ISchemaTypeProvider BuildClientEnum(SealedChoiceSchema sealedChoiceSchema) => new ClientEnum(
            sealedChoiceSchema,
            sealedChoiceSchema.CSharpName(),
            CreateDescription(sealedChoiceSchema),
            sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(
                c.CSharpName(),
                CreateDescription(c),
                ClientModelBuilderHelpers.StringConstant(c.Value))));

        private static ISchemaTypeProvider BuildClientEnum(ChoiceSchema choiceSchema) => new ClientEnum(
            choiceSchema,
            choiceSchema.CSharpName(),
            CreateDescription(choiceSchema),
            choiceSchema.Choices.Select(c => new ClientEnumValue(
                c.CSharpName(),
                CreateDescription(c),
                ClientModelBuilderHelpers.StringConstant(c.Value))),
            true);

        private ISchemaTypeProvider BuildClientObject(ObjectSchema objectSchema)
        {
            ClientTypeReference? inheritsFromTypeReference = null;
            DictionarySchema? inheritedDictionarySchema = null;

            foreach (ComplexSchema complexSchema in objectSchema.Parents!.Immediate)
            {
                switch (complexSchema)
                {
                    case ObjectSchema parentObjectSchema:
                        inheritsFromTypeReference = ClientModelBuilderHelpers.CreateType(parentObjectSchema, false);
                        break;
                    case DictionarySchema dictionarySchema:
                        inheritedDictionarySchema = dictionarySchema;
                        break;
                }
            }

            List<ClientObjectProperty> properties = new List<ClientObjectProperty>();

            foreach (Property property in objectSchema.Properties!)
            {
                ClientObjectProperty clientObjectProperty = CreateProperty(property);
                properties.Add(clientObjectProperty);
            }

            Discriminator? schemaDiscriminator = objectSchema.Discriminator;
            ClientObjectDiscriminator? discriminator = null;

            if (schemaDiscriminator == null && objectSchema.DiscriminatorValue != null)
            {
                schemaDiscriminator = objectSchema.Parents!.All.OfType<ObjectSchema>().First(p => p.Discriminator != null).Discriminator;

                Debug.Assert(schemaDiscriminator != null);

                discriminator = new ClientObjectDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    Array.Empty<ClientObjectDiscriminatorImplementation>(),
                    objectSchema.DiscriminatorValue
                );
            }
            else if (schemaDiscriminator != null)
            {
                discriminator = new ClientObjectDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    CreateDiscriminatorImplementations(schemaDiscriminator),
                    objectSchema.DiscriminatorValue
                    );
            }

            return new ClientObject(
                objectSchema,
                objectSchema.CSharpName(),
                CreateDescription(objectSchema),
                (SchemaTypeReference?) inheritsFromTypeReference,
                properties.ToArray(),
                discriminator,
                inheritedDictionarySchema == null ? null : CreateDictionaryType(inheritedDictionarySchema),
                BuildSerializations(objectSchema)
                );
        }

        private ObjectSerialization[] BuildSerializations(ObjectSchema objectSchema)
        {
            return _mediaTypes.Select(type => SerializationBuilder.BuildObject(type, objectSchema, isNullable: false)).ToArray();
        }

        private static DictionaryTypeReference CreateDictionaryType(DictionarySchema inheritedDictionarySchema)
        {
            return new DictionaryTypeReference(
                new FrameworkTypeReference(typeof(string)),
                ClientModelBuilderHelpers.CreateType(inheritedDictionarySchema.ElementType, false),
                false);
        }

        private static ClientObjectDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ClientObjectDiscriminatorImplementation(
                implementation.Key,
                (SchemaTypeReference)ClientModelBuilderHelpers.CreateType(implementation.Value, false),
                schemaDiscriminator.Immediate.ContainsKey(implementation.Key)
            )).ToArray();
        }

        public ISchemaTypeProvider BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => BuildClientEnum(sealedChoiceSchema),
            ChoiceSchema choiceSchema => BuildClientEnum(choiceSchema),
            ObjectSchema objectSchema => BuildClientObject(objectSchema),
            _ => throw new NotImplementedException()
        };

        private static ClientObjectProperty CreateProperty(Property property)
        {
            bool isReadOnly = property.IsDiscriminator == true || property.ReadOnly == true;

            ClientConstant? defaultValue = null;

            ClientTypeReference type;
            if (property.Schema is ConstantSchema constantSchema)
            {
                type = ClientModelBuilderHelpers.CreateType(constantSchema.ValueType, false);
                defaultValue = ClientModelBuilderHelpers.ParseClientConstant(constantSchema.Value.Value, type);
            }
            else
            {
                type = ClientModelBuilderHelpers.CreateType(property.Schema, property.IsNullable());
                if (property.ClientDefaultValue != null)
                {
                    defaultValue = ClientModelBuilderHelpers.ParseClientConstant(property.ClientDefaultValue, type);
                }
            }

            return new ClientObjectProperty(property.CSharpName(),
                ClientModelBuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                type,
                isReadOnly,
                defaultValue);
        }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ?
                choiceValue.Value :
                ClientModelBuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }

        private static string CreateDescription(Schema objectSchema)
        {
            return string.IsNullOrWhiteSpace(objectSchema.Language.Default.Description) ?
                $"The {objectSchema.Name}." :
                ClientModelBuilderHelpers.EscapeXmlDescription(objectSchema.Language.Default.Description);
        }
    }
}
