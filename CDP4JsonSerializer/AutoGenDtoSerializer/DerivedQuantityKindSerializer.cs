// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DerivedQuantityKindSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DerivedQuantityKindSerializer"/> class is to provide a <see cref="DerivedQuantityKind"/> specific serializer
    /// </summary>
    public class DerivedQuantityKindSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultScale", defaultScale => new JValue(defaultScale) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "possibleScale", possibleScale => new JArray(possibleScale) },
            { "quantityDimensionSymbol", quantityDimensionSymbol => new JValue(quantityDimensionSymbol) },
            { "quantityKindFactor", quantityKindFactor => new JArray(((IEnumerable)quantityKindFactor).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="DerivedQuantityKind"/>
        /// </summary>
        /// <param name="derivedQuantityKind">The <see cref="DerivedQuantityKind"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DerivedQuantityKind derivedQuantityKind)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](derivedQuantityKind.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](derivedQuantityKind.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), derivedQuantityKind.ClassKind)));
            jsonObject.Add("defaultScale", this.PropertySerializerMap["defaultScale"](derivedQuantityKind.DefaultScale));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](derivedQuantityKind.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](derivedQuantityKind.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](derivedQuantityKind.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](derivedQuantityKind.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](derivedQuantityKind.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](derivedQuantityKind.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](derivedQuantityKind.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](derivedQuantityKind.Name));
            jsonObject.Add("possibleScale", this.PropertySerializerMap["possibleScale"](derivedQuantityKind.PossibleScale));
            jsonObject.Add("quantityDimensionSymbol", this.PropertySerializerMap["quantityDimensionSymbol"](derivedQuantityKind.QuantityDimensionSymbol));
            jsonObject.Add("quantityKindFactor", this.PropertySerializerMap["quantityKindFactor"](derivedQuantityKind.QuantityKindFactor));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](derivedQuantityKind.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](derivedQuantityKind.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](derivedQuantityKind.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DerivedQuantityKind"/> class.
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

            var derivedQuantityKind = thing as DerivedQuantityKind;
            if (derivedQuantityKind == null)
            {
                throw new InvalidOperationException("The thing is not a DerivedQuantityKind.");
            }

            return this.Serialize(derivedQuantityKind);
        }
    }
}
