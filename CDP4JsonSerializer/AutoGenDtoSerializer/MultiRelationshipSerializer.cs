// --------------------------------------------------------------------------------------------------------------------
// <copyright file "MultiRelationshipSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MultiRelationshipSerializer"/> class is to provide a <see cref="MultiRelationship"/> specific serializer
    /// </summary>
    public class MultiRelationshipSerializer : IThingSerializer
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
            { "relatedThing", relatedThing => new JArray(relatedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="MultiRelationship"/>
        /// </summary>
        /// <param name="multiRelationship">The <see cref="MultiRelationship"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(MultiRelationship multiRelationship)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](multiRelationship.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), multiRelationship.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](multiRelationship.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](multiRelationship.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](multiRelationship.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](multiRelationship.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](multiRelationship.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](multiRelationship.ParameterValue));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](multiRelationship.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](multiRelationship.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="MultiRelationship"/> class.
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

            var multiRelationship = thing as MultiRelationship;
            if (multiRelationship == null)
            {
                throw new InvalidOperationException("The thing is not a MultiRelationship.");
            }

            return this.Serialize(multiRelationship);
        }
    }
}
