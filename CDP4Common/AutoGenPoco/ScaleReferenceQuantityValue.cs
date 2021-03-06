// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleReferenceQuantityValue.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
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
    /// representation of a reference quantity with value for the definition of logarithmic MeasurementScales
    /// Note: See property <i>referenceQuantity</i> of LogarithmicScale for details.
    /// </summary>
    [Container(typeof(LogarithmicScale), "ReferenceQuantityValue")]
    public sealed partial class ScaleReferenceQuantityValue : Thing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleReferenceQuantityValue"/> class.
        /// </summary>
        public ScaleReferenceQuantityValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleReferenceQuantityValue"/> class.
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
        public ScaleReferenceQuantityValue(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// reference to the MeasurementScale on which the <i>value</i> is expressed
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public MeasurementScale Scale { get; set; }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        /// <remarks>
        /// definition of the value of this ScaleReferenceQuantityValue
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Value { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ScaleReferenceQuantityValue"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ScaleReferenceQuantityValue"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ScaleReferenceQuantityValue)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="ScaleReferenceQuantityValue"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ScaleReferenceQuantityValue"/>.
        /// </returns>
        public new ScaleReferenceQuantityValue Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ScaleReferenceQuantityValue)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ScaleReferenceQuantityValue"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Scale == null || this.Scale.Iid == Guid.Empty)
            {
                errorList.Add("The property Scale is null.");
                this.Scale = SentinelThingProvider.GetSentinel<MeasurementScale>();
                this.sentinelResetMap["Scale"] = () => this.Scale = null;
            }

            if (string.IsNullOrWhiteSpace(this.Value))
            {
                errorList.Add("The property Value is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ScaleReferenceQuantityValue"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ScaleReferenceQuantityValue;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ScaleReferenceQuantityValue POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.Scale = this.Cache.Get<MeasurementScale>(dto.Scale, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<MeasurementScale>();
            this.Value = dto.Value;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ScaleReferenceQuantityValue"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ScaleReferenceQuantityValue(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Scale = this.Scale != null ? this.Scale.Iid : Guid.Empty;
            dto.Value = this.Value;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
