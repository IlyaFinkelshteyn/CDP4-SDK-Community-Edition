// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSetupResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelSetup"/>
    /// </summary>
    public static class EngineeringModelSetupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelSetup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var engineeringModelSetup = new CDP4Common.DTO.EngineeringModelSetup(iid, revisionNumber);

            if (!jObject["activeDomain"].IsNullOrEmpty())
            {
                engineeringModelSetup.ActiveDomain.AddRange(jObject["activeDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                engineeringModelSetup.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                engineeringModelSetup.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["engineeringModelIid"].IsNullOrEmpty())
            {
                engineeringModelSetup.EngineeringModelIid = jObject["engineeringModelIid"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                engineeringModelSetup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                engineeringModelSetup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                engineeringModelSetup.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["iterationSetup"].IsNullOrEmpty())
            {
                engineeringModelSetup.IterationSetup.AddRange(jObject["iterationSetup"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["kind"].IsNullOrEmpty())
            {
                engineeringModelSetup.Kind = jObject["kind"].ToObject<EngineeringModelKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                engineeringModelSetup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                engineeringModelSetup.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["participant"].IsNullOrEmpty())
            {
                engineeringModelSetup.Participant.AddRange(jObject["participant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["requiredRdl"].IsNullOrEmpty())
            {
                engineeringModelSetup.RequiredRdl.AddRange(jObject["requiredRdl"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                engineeringModelSetup.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceEngineeringModelSetupIid"].IsNullOrEmpty())
            {
                engineeringModelSetup.SourceEngineeringModelSetupIid = jObject["sourceEngineeringModelSetupIid"].ToObject<Guid?>();
            }

            if (!jObject["studyPhase"].IsNullOrEmpty())
            {
                engineeringModelSetup.StudyPhase = jObject["studyPhase"].ToObject<StudyPhaseKind>();
            }

            return engineeringModelSetup;
        }
    }
}
