// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BinaryRelationshipSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryRelationshipSerializer"/> class is to provide a <see cref="BinaryRelationship"/> specific serializer
    /// </summary>
    public class BinaryRelationshipSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "parameterValue", parameterValue => new JArray(parameterValue) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "source", source => new JValue(source) },
            { "target", target => new JValue(target) },
        };

        /// <summary>
        /// Serialize the <see cref="BinaryRelationship"/>
        /// </summary>
        /// <param name="binaryRelationship">The <see cref="BinaryRelationship"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(BinaryRelationship binaryRelationship)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](binaryRelationship.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), binaryRelationship.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](binaryRelationship.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](binaryRelationship.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](binaryRelationship.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](binaryRelationship.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](binaryRelationship.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](binaryRelationship.ParameterValue));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](binaryRelationship.RevisionNumber));
            jsonObject.Add("source", this.PropertySerializerMap["source"](binaryRelationship.Source));
            jsonObject.Add("target", this.PropertySerializerMap["target"](binaryRelationship.Target));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BinaryRelationship"/> class.
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

            var binaryRelationship = thing as BinaryRelationship;
            if (binaryRelationship == null)
            {
                throw new InvalidOperationException("The thing is not a BinaryRelationship.");
            }

            return this.Serialize(binaryRelationship);
        }
    }
}
