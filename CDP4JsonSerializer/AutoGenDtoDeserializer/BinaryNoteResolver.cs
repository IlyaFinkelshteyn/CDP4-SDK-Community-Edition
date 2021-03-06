// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryNoteResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="BinaryNoteResolver"/> is to deserialize a JSON object to a <see cref="BinaryNote"/>
    /// </summary>
    public static class BinaryNoteResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BinaryNote"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BinaryNote"/> to instantiate</returns>
        public static CDP4Common.DTO.BinaryNote FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var binaryNote = new CDP4Common.DTO.BinaryNote(iid, revisionNumber);

            if (!jObject["caption"].IsNullOrEmpty())
            {
                binaryNote.Caption = jObject["caption"].ToObject<string>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                binaryNote.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                binaryNote.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                binaryNote.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                binaryNote.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileType"].IsNullOrEmpty())
            {
                binaryNote.FileType = jObject["fileType"].ToObject<Guid>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                binaryNote.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                binaryNote.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                binaryNote.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                binaryNote.ShortName = jObject["shortName"].ToObject<string>();
            }

            return binaryNote;
        }
    }
}
