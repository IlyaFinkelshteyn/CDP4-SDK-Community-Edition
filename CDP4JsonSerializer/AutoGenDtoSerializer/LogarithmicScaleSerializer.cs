// --------------------------------------------------------------------------------------------------------------------
// <copyright file "LogarithmicScaleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="LogarithmicScaleSerializer"/> class is to provide a <see cref="LogarithmicScale"/> specific serializer
    /// </summary>
    public class LogarithmicScaleSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "exponent", exponent => new JValue(exponent) },
            { "factor", factor => new JValue(factor) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "isMaximumInclusive", isMaximumInclusive => new JValue(isMaximumInclusive) },
            { "isMinimumInclusive", isMinimumInclusive => new JValue(isMinimumInclusive) },
            { "logarithmBase", logarithmBase => new JValue(logarithmBase.ToString()) },
            { "mappingToReferenceScale", mappingToReferenceScale => new JArray(mappingToReferenceScale) },
            { "maximumPermissibleValue", maximumPermissibleValue => new JValue(maximumPermissibleValue) },
            { "minimumPermissibleValue", minimumPermissibleValue => new JValue(minimumPermissibleValue) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "negativeValueConnotation", negativeValueConnotation => new JValue(negativeValueConnotation) },
            { "numberSet", numberSet => new JValue(numberSet.ToString()) },
            { "positiveValueConnotation", positiveValueConnotation => new JValue(positiveValueConnotation) },
            { "referenceQuantityKind", referenceQuantityKind => new JValue(referenceQuantityKind) },
            { "referenceQuantityValue", referenceQuantityValue => new JArray(referenceQuantityValue) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "unit", unit => new JValue(unit) },
            { "valueDefinition", valueDefinition => new JArray(valueDefinition) },
        };

        /// <summary>
        /// Serialize the <see cref="LogarithmicScale"/>
        /// </summary>
        /// <param name="logarithmicScale">The <see cref="LogarithmicScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(LogarithmicScale logarithmicScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](logarithmicScale.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), logarithmicScale.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](logarithmicScale.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](logarithmicScale.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](logarithmicScale.ExcludedPerson));
            jsonObject.Add("exponent", this.PropertySerializerMap["exponent"](logarithmicScale.Exponent));
            jsonObject.Add("factor", this.PropertySerializerMap["factor"](logarithmicScale.Factor));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](logarithmicScale.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](logarithmicScale.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](logarithmicScale.IsDeprecated));
            jsonObject.Add("isMaximumInclusive", this.PropertySerializerMap["isMaximumInclusive"](logarithmicScale.IsMaximumInclusive));
            jsonObject.Add("isMinimumInclusive", this.PropertySerializerMap["isMinimumInclusive"](logarithmicScale.IsMinimumInclusive));
            jsonObject.Add("logarithmBase", this.PropertySerializerMap["logarithmBase"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.LogarithmBaseKind), logarithmicScale.LogarithmBase)));
            jsonObject.Add("mappingToReferenceScale", this.PropertySerializerMap["mappingToReferenceScale"](logarithmicScale.MappingToReferenceScale));
            jsonObject.Add("maximumPermissibleValue", this.PropertySerializerMap["maximumPermissibleValue"](logarithmicScale.MaximumPermissibleValue));
            jsonObject.Add("minimumPermissibleValue", this.PropertySerializerMap["minimumPermissibleValue"](logarithmicScale.MinimumPermissibleValue));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](logarithmicScale.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](logarithmicScale.Name));
            jsonObject.Add("negativeValueConnotation", this.PropertySerializerMap["negativeValueConnotation"](logarithmicScale.NegativeValueConnotation));
            jsonObject.Add("numberSet", this.PropertySerializerMap["numberSet"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), logarithmicScale.NumberSet)));
            jsonObject.Add("positiveValueConnotation", this.PropertySerializerMap["positiveValueConnotation"](logarithmicScale.PositiveValueConnotation));
            jsonObject.Add("referenceQuantityKind", this.PropertySerializerMap["referenceQuantityKind"](logarithmicScale.ReferenceQuantityKind));
            jsonObject.Add("referenceQuantityValue", this.PropertySerializerMap["referenceQuantityValue"](logarithmicScale.ReferenceQuantityValue));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](logarithmicScale.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](logarithmicScale.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](logarithmicScale.Unit));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](logarithmicScale.ValueDefinition));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="LogarithmicScale"/> class.
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

            var logarithmicScale = thing as LogarithmicScale;
            if (logarithmicScale == null)
            {
                throw new InvalidOperationException("The thing is not a LogarithmicScale.");
            }

            return this.Serialize(logarithmicScale);
        }
    }
}
