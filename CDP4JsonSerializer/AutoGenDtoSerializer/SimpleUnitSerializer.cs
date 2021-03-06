// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SimpleUnitSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SimpleUnitSerializer"/> class is to provide a <see cref="SimpleUnit"/> specific serializer
    /// </summary>
    public class SimpleUnitSerializer : IThingSerializer
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
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="SimpleUnit"/>
        /// </summary>
        /// <param name="simpleUnit">The <see cref="SimpleUnit"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SimpleUnit simpleUnit)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](simpleUnit.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), simpleUnit.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](simpleUnit.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](simpleUnit.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](simpleUnit.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](simpleUnit.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](simpleUnit.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](simpleUnit.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](simpleUnit.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](simpleUnit.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](simpleUnit.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](simpleUnit.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SimpleUnit"/> class.
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

            var simpleUnit = thing as SimpleUnit;
            if (simpleUnit == null)
            {
                throw new InvalidOperationException("The thing is not a SimpleUnit.");
            }

            return this.Serialize(simpleUnit);
        }
    }
}
