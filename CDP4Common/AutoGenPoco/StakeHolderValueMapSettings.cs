// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapSettings.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// The settings of a StakeholderValueMap that capture the BinaryRelationshipRules that are used to create links between the Goals, ValueGroup, StakeholderValues and Requirements
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(StakeHolderValueMap), "Settings")]
    public sealed partial class StakeHolderValueMapSettings : Thing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="StakeHolderValueMapSettings"/> class.
        /// </summary>
        public StakeHolderValueMapSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StakeHolderValueMapSettings"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public StakeHolderValueMapSettings(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the GoalToValueGroupRelationship.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public BinaryRelationshipRule GoalToValueGroupRelationship { get; set; }

        /// <summary>
        /// Gets or sets the StakeholderValueToRequirementRelationship.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public BinaryRelationshipRule StakeholderValueToRequirementRelationship { get; set; }

        /// <summary>
        /// Gets or sets the ValueGroupToStakeholderValueRelationship.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public BinaryRelationshipRule ValueGroupToStakeholderValueRelationship { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="StakeHolderValueMapSettings"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="StakeHolderValueMapSettings"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (StakeHolderValueMapSettings)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="StakeHolderValueMapSettings"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="StakeHolderValueMapSettings"/>.
        /// </returns>
        public new StakeHolderValueMapSettings Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (StakeHolderValueMapSettings)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="StakeHolderValueMapSettings"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="StakeHolderValueMapSettings"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.StakeHolderValueMapSettings;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current StakeHolderValueMapSettings POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.GoalToValueGroupRelationship = (dto.GoalToValueGroupRelationship.HasValue) ? this.Cache.Get<BinaryRelationshipRule>(dto.GoalToValueGroupRelationship.Value, dto.IterationContainerId) : null;
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.StakeholderValueToRequirementRelationship = (dto.StakeholderValueToRequirementRelationship.HasValue) ? this.Cache.Get<BinaryRelationshipRule>(dto.StakeholderValueToRequirementRelationship.Value, dto.IterationContainerId) : null;
            this.ValueGroupToStakeholderValueRelationship = (dto.ValueGroupToStakeholderValueRelationship.HasValue) ? this.Cache.Get<BinaryRelationshipRule>(dto.ValueGroupToStakeholderValueRelationship.Value, dto.IterationContainerId) : null;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="StakeHolderValueMapSettings"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.StakeHolderValueMapSettings(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.GoalToValueGroupRelationship = this.GoalToValueGroupRelationship != null ? (Guid?)this.GoalToValueGroupRelationship.Iid : null;
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.StakeholderValueToRequirementRelationship = this.StakeholderValueToRequirementRelationship != null ? (Guid?)this.StakeholderValueToRequirementRelationship.Iid : null;
            dto.ValueGroupToStakeholderValueRelationship = this.ValueGroupToStakeholderValueRelationship != null ? (Guid?)this.ValueGroupToStakeholderValueRelationship.Iid : null;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
