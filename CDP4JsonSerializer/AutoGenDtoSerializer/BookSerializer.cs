// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BookSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BookSerializer"/> class is to provide a <see cref="Book"/> specific serializer
    /// </summary>
    public class BookSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "section", section => new JArray(((IEnumerable)section).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="Book"/>
        /// </summary>
        /// <param name="book">The <see cref="Book"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Book book)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](book.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), book.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](book.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](book.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](book.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](book.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](book.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](book.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](book.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](book.RevisionNumber));
            jsonObject.Add("section", this.PropertySerializerMap["section"](book.Section));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](book.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Book"/> class.
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

            var book = thing as Book;
            if (book == null)
            {
                throw new InvalidOperationException("The thing is not a Book.");
            }

            return this.Serialize(book);
        }
    }
}
