// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantPermissionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParticipantPermissionResolver"/> is to deserialize a JSON object to a <see cref="ParticipantPermission"/>
    /// </summary>
    public static class ParticipantPermissionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParticipantPermission"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParticipantPermission"/> to instantiate</returns>
        public static CDP4Common.DTO.ParticipantPermission FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var participantPermission = new CDP4Common.DTO.ParticipantPermission(iid, revisionNumber);

            if (!jObject["accessRight"].IsNullOrEmpty())
            {
                participantPermission.AccessRight = jObject["accessRight"].ToObject<ParticipantAccessRightKind>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                participantPermission.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                participantPermission.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                participantPermission.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                participantPermission.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["objectClass"].IsNullOrEmpty())
            {
                participantPermission.ObjectClass = jObject["objectClass"].ToObject<ClassKind>();
            }

            return participantPermission;
        }
    }
}
