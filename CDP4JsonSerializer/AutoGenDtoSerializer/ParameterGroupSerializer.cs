// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterGroupSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterGroupSerializer"/> class is to provide a <see cref="ParameterGroup"/> specific serializer
    /// </summary>
    public class ParameterGroupSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containingGroup", containingGroup => new JValue(containingGroup) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterGroup"/>
        /// </summary>
        /// <param name="parameterGroup">The <see cref="ParameterGroup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterGroup parameterGroup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterGroup.ClassKind)));
            jsonObject.Add("containingGroup", this.PropertySerializerMap["containingGroup"](parameterGroup.ContainingGroup));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterGroup.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterGroup.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterGroup.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterGroup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](parameterGroup.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterGroup.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterGroup"/> class.
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

            var parameterGroup = thing as ParameterGroup;
            if (parameterGroup == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterGroup.");
            }

            return this.Serialize(parameterGroup);
        }
    }
}
