// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BinaryRelationshipRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryRelationshipRuleSerializer"/> class is to provide a <see cref="BinaryRelationshipRule"/> specific serializer
    /// </summary>
    public class BinaryRelationshipRuleSerializer : IThingSerializer
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
            { "forwardRelationshipName", forwardRelationshipName => new JValue(forwardRelationshipName) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "inverseRelationshipName", inverseRelationshipName => new JValue(inverseRelationshipName) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "relationshipCategory", relationshipCategory => new JValue(relationshipCategory) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "sourceCategory", sourceCategory => new JValue(sourceCategory) },
            { "targetCategory", targetCategory => new JValue(targetCategory) },
        };

        /// <summary>
        /// Serialize the <see cref="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="binaryRelationshipRule">The <see cref="BinaryRelationshipRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(BinaryRelationshipRule binaryRelationshipRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](binaryRelationshipRule.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), binaryRelationshipRule.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](binaryRelationshipRule.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](binaryRelationshipRule.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](binaryRelationshipRule.ExcludedPerson));
            jsonObject.Add("forwardRelationshipName", this.PropertySerializerMap["forwardRelationshipName"](binaryRelationshipRule.ForwardRelationshipName));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](binaryRelationshipRule.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](binaryRelationshipRule.Iid));
            jsonObject.Add("inverseRelationshipName", this.PropertySerializerMap["inverseRelationshipName"](binaryRelationshipRule.InverseRelationshipName));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](binaryRelationshipRule.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](binaryRelationshipRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](binaryRelationshipRule.Name));
            jsonObject.Add("relationshipCategory", this.PropertySerializerMap["relationshipCategory"](binaryRelationshipRule.RelationshipCategory));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](binaryRelationshipRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](binaryRelationshipRule.ShortName));
            jsonObject.Add("sourceCategory", this.PropertySerializerMap["sourceCategory"](binaryRelationshipRule.SourceCategory));
            jsonObject.Add("targetCategory", this.PropertySerializerMap["targetCategory"](binaryRelationshipRule.TargetCategory));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BinaryRelationshipRule"/> class.
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

            var binaryRelationshipRule = thing as BinaryRelationshipRule;
            if (binaryRelationshipRule == null)
            {
                throw new InvalidOperationException("The thing is not a BinaryRelationshipRule.");
            }

            return this.Serialize(binaryRelationshipRule);
        }
    }
}
