// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataDiscussionItem.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
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
    /// The DiscussionItem is the concept that carries an intervention made by a participant after a ModellingAnnotationItem has been created following a review.
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModelDataAnnotation), "Discussion")]
    public sealed partial class EngineeringModelDataDiscussionItem : DiscussionItem
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NONE;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataDiscussionItem"/> class.
        /// </summary>
        public EngineeringModelDataDiscussionItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataDiscussionItem"/> class.
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
        public EngineeringModelDataDiscussionItem(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// The participant that is the author of the DiscussionItem
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Participant Author { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModelDataDiscussionItem"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModelDataDiscussionItem"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (EngineeringModelDataDiscussionItem)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="EngineeringModelDataDiscussionItem"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModelDataDiscussionItem"/>.
        /// </returns>
        public new EngineeringModelDataDiscussionItem Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (EngineeringModelDataDiscussionItem)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="EngineeringModelDataDiscussionItem"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Author == null || this.Author.Iid == Guid.Empty)
            {
                errorList.Add("The property Author is null.");
                this.Author = SentinelThingProvider.GetSentinel<Participant>();
                this.sentinelResetMap["Author"] = () => this.Author = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="EngineeringModelDataDiscussionItem"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.EngineeringModelDataDiscussionItem;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current EngineeringModelDataDiscussionItem POCO.", dtoThing.GetType()));
            }

            this.Author = this.Cache.Get<Participant>(dto.Author, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.Content = dto.Content;
            this.CreatedOn = dto.CreatedOn;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LanguageCode = dto.LanguageCode;
            this.ModifiedOn = dto.ModifiedOn;
            this.ReplyTo = (dto.ReplyTo.HasValue) ? this.Cache.Get<DiscussionItem>(dto.ReplyTo.Value, dto.IterationContainerId) : null;
            this.RevisionNumber = dto.RevisionNumber;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="EngineeringModelDataDiscussionItem"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.EngineeringModelDataDiscussionItem(this.Iid, this.RevisionNumber);

            dto.Author = this.Author != null ? this.Author.Iid : Guid.Empty;
            dto.Content = this.Content;
            dto.CreatedOn = this.CreatedOn;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LanguageCode = this.LanguageCode;
            dto.ModifiedOn = this.ModifiedOn;
            dto.ReplyTo = this.ReplyTo != null ? (Guid?)this.ReplyTo.Iid : null;
            dto.RevisionNumber = this.RevisionNumber;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
