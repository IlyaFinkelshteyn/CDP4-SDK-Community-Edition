// --------------------------------------------------------------------------------------------------------------------
// <copyright file "LinearConversionUnitSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The purpose of the <see cref="LinearConversionUnitSerializer"/> class is to provide a <see cref="LinearConversionUnit"/> specific serializer
    /// </summary>
    public class LinearConversionUnitSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "conversionFactor", conversionFactor => new JValue(conversionFactor) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "referenceUnit", referenceUnit => new JValue(referenceUnit) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="LinearConversionUnit"/>
        /// </summary>
        /// <param name="linearConversionUnit">The <see cref="LinearConversionUnit"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(LinearConversionUnit linearConversionUnit)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](linearConversionUnit.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), linearConversionUnit.ClassKind)));
            jsonObject.Add("conversionFactor", this.PropertySerializerMap["conversionFactor"](linearConversionUnit.ConversionFactor));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](linearConversionUnit.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](linearConversionUnit.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](linearConversionUnit.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](linearConversionUnit.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](linearConversionUnit.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](linearConversionUnit.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](linearConversionUnit.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](linearConversionUnit.Name));
            jsonObject.Add("referenceUnit", this.PropertySerializerMap["referenceUnit"](linearConversionUnit.ReferenceUnit));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](linearConversionUnit.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](linearConversionUnit.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="LinearConversionUnit"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var linearConversionUnit = thing as LinearConversionUnit;
            if (linearConversionUnit == null)
            {
                throw new InvalidOperationException("The thing is not a LinearConversionUnit.");
            }

            return this.Serialize(linearConversionUnit);
        }
    }
}
