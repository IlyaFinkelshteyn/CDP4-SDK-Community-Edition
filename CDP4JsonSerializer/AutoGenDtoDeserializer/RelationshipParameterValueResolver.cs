// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipParameterValueResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RelationshipParameterValueResolver"/> is to deserialize a JSON object to a <see cref="RelationshipParameterValue"/>
    /// </summary>
    public static class RelationshipParameterValueResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RelationshipParameterValue"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RelationshipParameterValue"/> to instantiate</returns>
        public static CDP4Common.DTO.RelationshipParameterValue FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var relationshipParameterValue = new CDP4Common.DTO.RelationshipParameterValue(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                relationshipParameterValue.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                relationshipParameterValue.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                relationshipParameterValue.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                relationshipParameterValue.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                relationshipParameterValue.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                relationshipParameterValue.Value = SerializerHelper.ToValueArray<string>(jObject["value"].ToString());
            }

            return relationshipParameterValue;
        }
    }
}
