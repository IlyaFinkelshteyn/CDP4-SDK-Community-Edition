// --------------------------------------------------------------------------------------------------------------------
// <copyright file "CompoundParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CompoundParameterTypeSerializer"/> class is to provide a <see cref="CompoundParameterType"/> specific serializer
    /// </summary>
    public class CompoundParameterTypeSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "component", component => new JArray(((IEnumerable)component).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "isFinalized", isFinalized => new JValue(isFinalized) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="CompoundParameterType"/>
        /// </summary>
        /// <param name="compoundParameterType">The <see cref="CompoundParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(CompoundParameterType compoundParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](compoundParameterType.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](compoundParameterType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), compoundParameterType.ClassKind)));
            jsonObject.Add("component", this.PropertySerializerMap["component"](compoundParameterType.Component));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](compoundParameterType.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](compoundParameterType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](compoundParameterType.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](compoundParameterType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](compoundParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](compoundParameterType.IsDeprecated));
            jsonObject.Add("isFinalized", this.PropertySerializerMap["isFinalized"](compoundParameterType.IsFinalized));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](compoundParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](compoundParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](compoundParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](compoundParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](compoundParameterType.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="CompoundParameterType"/> class.
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

            var compoundParameterType = thing as CompoundParameterType;
            if (compoundParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a CompoundParameterType.");
            }

            return this.Serialize(compoundParameterType);
        }
    }
}
