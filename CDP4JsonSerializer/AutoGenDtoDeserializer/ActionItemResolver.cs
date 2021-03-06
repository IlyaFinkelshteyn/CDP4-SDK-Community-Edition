// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActionItemResolver"/> is to deserialize a JSON object to a <see cref="ActionItem"/>
    /// </summary>
    public static class ActionItemResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ActionItem"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ActionItem"/> to instantiate</returns>
        public static CDP4Common.DTO.ActionItem FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var actionItem = new CDP4Common.DTO.ActionItem(iid, revisionNumber);

            if (!jObject["actionee"].IsNullOrEmpty())
            {
                actionItem.Actionee = jObject["actionee"].ToObject<Guid>();
            }

            if (!jObject["approvedBy"].IsNullOrEmpty())
            {
                actionItem.ApprovedBy.AddRange(jObject["approvedBy"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                actionItem.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                actionItem.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["classification"].IsNullOrEmpty())
            {
                actionItem.Classification = jObject["classification"].ToObject<AnnotationClassificationKind>();
            }

            if (!jObject["closeOutDate"].IsNullOrEmpty())
            {
                actionItem.CloseOutDate = jObject["closeOutDate"].ToObject<DateTime?>();
            }

            if (!jObject["closeOutStatement"].IsNullOrEmpty())
            {
                actionItem.CloseOutStatement = jObject["closeOutStatement"].ToObject<string>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                actionItem.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                actionItem.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                actionItem.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["dueDate"].IsNullOrEmpty())
            {
                actionItem.DueDate = jObject["dueDate"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                actionItem.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                actionItem.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                actionItem.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                actionItem.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                actionItem.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                actionItem.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid?>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                actionItem.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                actionItem.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceAnnotation"].IsNullOrEmpty())
            {
                actionItem.SourceAnnotation.AddRange(jObject["sourceAnnotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                actionItem.Status = jObject["status"].ToObject<AnnotationStatusKind>();
            }

            if (!jObject["title"].IsNullOrEmpty())
            {
                actionItem.Title = jObject["title"].ToObject<string>();
            }

            return actionItem;
        }
    }
}
