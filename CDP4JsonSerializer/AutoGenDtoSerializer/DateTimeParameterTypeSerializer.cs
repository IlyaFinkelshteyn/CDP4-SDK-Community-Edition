// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DateTimeParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DateTimeParameterTypeSerializer"/> class is to provide a <see cref="DateTimeParameterType"/> specific serializer
    /// </summary>
    public class DateTimeParameterTypeSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
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
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="DateTimeParameterType"/>
        /// </summary>
        /// <param name="dateTimeParameterType">The <see cref="DateTimeParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DateTimeParameterType dateTimeParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](dateTimeParameterType.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](dateTimeParameterType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), dateTimeParameterType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](dateTimeParameterType.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](dateTimeParameterType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](dateTimeParameterType.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](dateTimeParameterType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](dateTimeParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](dateTimeParameterType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](dateTimeParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](dateTimeParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](dateTimeParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](dateTimeParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](dateTimeParameterType.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DateTimeParameterType"/> class.
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

            var dateTimeParameterType = thing as DateTimeParameterType;
            if (dateTimeParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a DateTimeParameterType.");
            }

            return this.Serialize(dateTimeParameterType);
        }
    }
}
