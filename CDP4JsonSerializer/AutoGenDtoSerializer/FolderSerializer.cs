// --------------------------------------------------------------------------------------------------------------------
// <copyright file "FolderSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FolderSerializer"/> class is to provide a <see cref="Folder"/> specific serializer
    /// </summary>
    public class FolderSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containingFolder", containingFolder => new JValue(containingFolder) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "creator", creator => new JValue(creator) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="Folder"/>
        /// </summary>
        /// <param name="folder">The <see cref="Folder"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Folder folder)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), folder.ClassKind)));
            jsonObject.Add("containingFolder", this.PropertySerializerMap["containingFolder"](folder.ContainingFolder));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](folder.CreatedOn));
            jsonObject.Add("creator", this.PropertySerializerMap["creator"](folder.Creator));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](folder.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](folder.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](folder.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](folder.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](folder.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](folder.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](folder.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Folder"/> class.
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

            var folder = thing as Folder;
            if (folder == null)
            {
                throw new InvalidOperationException("The thing is not a Folder.");
            }

            return this.Serialize(folder);
        }
    }
}
