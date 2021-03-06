// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinition.cs" company="RHEA System S.A.">
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
    /// definition of an element in a design solution for a system-of-interest
    /// Note 1: An element is defined once (as an ElementDefinition) and then can be used (as an ElementUsage) any number of times in a design solution for the system-of-interest.
    /// Note 2: The ElementDefinition and ElementUsage structure together form the representation of the hierarchical design composition / decomposition of the system-of-interest. Through the combination of the <i>containedElement</i> property and the <i>referencedElement</i> property of ElementUsage a hybrid product tree can be represented in which both logical and concrete (aka physical) architecture are combined.
    /// Note 3: Because of the containment relationship between ElementDefinition and ElementUsage, there is special behaviour with respect to Category membership. If an ElementDefinition is defined to be a member of a Category (through its category property), then also any ElementUsage that is typed by this ElementDefinition is a member of that Category.
    /// Example: The design of gyroscope "GS-123" is defined in an ElementDefinition and then 4 gyroscopes of this type are used as part of the attitude and orbit control equipment through 4 ElementUsages with names "x-gyro", "y-gyro", "z-gyro" and "xyz-gyro". All 4 usages are said to be of <i>type</i> "GS-123".
    /// Note 3: ElementDefinition is the equivalent of the concept of <i>Block</i> in OMG SysML. ElementUsage is the equivalent of the concept of <i>Part</i> in OMG SysML.
    /// </summary>
    [Container(typeof(Iteration), "Element")]
    public sealed partial class ElementDefinition : ElementBase
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
        /// Initializes a new instance of the <see cref="ElementDefinition"/> class.
        /// </summary>
        public ElementDefinition()
        {
            this.ContainedElement = new ContainerList<ElementUsage>(this);
            this.Parameter = new ContainerList<Parameter>(this);
            this.ParameterGroup = new ContainerList<ParameterGroup>(this);
            this.ReferencedElement = new List<NestedElement>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementDefinition"/> class.
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
        public ElementDefinition(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ContainedElement = new ContainerList<ElementUsage>(this);
            this.Parameter = new ContainerList<Parameter>(this);
            this.ParameterGroup = new ContainerList<ParameterGroup>(this);
            this.ReferencedElement = new List<NestedElement>();
        }

        /// <summary>
        /// Gets or sets a list of contained ElementUsage.
        /// </summary>
        /// <remarks>
        /// list of zero or more usages of elements at the next lower level of hierarchical decomposition, where each element is defined (typed) by an(other) ElementDefinition
        /// Note 1: This property captures the whole-part relationship between an ElementDefinition (the whole, the <i>containingElement</i>) and an ElementUsage (the part, the <i>containedElement</i>). This implies that the ElementUsage is existence dependent on the <i>containingElement</i> ElementDefinition. If the ElementDefinition is removed from the system-of-interest also its dependent ElementUsages are removed, as well as any subtree of ElementUsages subtended below the first lower level.
        /// Note 2: The permitted <i>containedElement</i> and <i>referencedElement</i> collections can be defined through a combination of appropriate Categories, DecompositionRules and ReferencerRules.
        /// Note 3: The <i>containedElement</i> property is the equivalent of a <i>part property</i> of a <i>Block</i> in OMG SysML.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ElementUsage> ContainedElement { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Parameter.
        /// </summary>
        /// <remarks>
        /// collection of Parameters that define characteristics of this ElementDefinition
        /// Note: Parameters and ParameterValueSets together form the parametric definition of this ElementDefinition as well as of ElementUsages that are typed by this ElementDefinition.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Parameter> Parameter { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ParameterGroup.
        /// </summary>
        /// <remarks>
        /// collection of ParameterGroups that define a grouping hierarchy to hold the Parameters of this ElementDefinition
        /// Note: This grouping does not carry specific meaning, but is a convenience mechanism to assist in the management and presentation of large sets of parameters.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParameterGroup> ParameterGroup { get; protected set; }

        /// <summary>
        /// Gets or sets a list of NestedElement.
        /// </summary>
        /// <remarks>
        /// zero or more references to ElementUsages at lower level(s) in the hierarchical decomposition of the system-of-interest
        /// Note 1: Referencing elements through NestedElements is a flexible and unconstrained mechanism to support network-type architectures and ad-hoc structures. The semantics of these references need to be defined through appropriate Categories that are associated with the participating ElementDefinitions, ElementUsages and NestedElements. Since the Categories are defined in ReferenceDataLibraries the interpretation of such references is therefore reference data dependent.
        /// Note 2: In order to adhere to the principle of strict modularity, the only permissible referencedElement(s) are ElementUsage(s) contained in the subtree of this ElementDefinition.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<NestedElement> ReferencedElement { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ElementDefinition"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ContainedElement);
                containers.Add(this.Parameter);
                containers.Add(this.ParameterGroup);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ElementDefinition"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ElementDefinition"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ElementDefinition)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Category = new List<Category>(this.Category);
            clone.ContainedElement = cloneContainedThings ? new ContainerList<ElementUsage>(clone) : new ContainerList<ElementUsage>(this.ContainedElement, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.Parameter = cloneContainedThings ? new ContainerList<Parameter>(clone) : new ContainerList<Parameter>(this.Parameter, clone);
            clone.ParameterGroup = cloneContainedThings ? new ContainerList<ParameterGroup>(clone) : new ContainerList<ParameterGroup>(this.ParameterGroup, clone);
            clone.ReferencedElement = new List<NestedElement>(this.ReferencedElement);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.ContainedElement.AddRange(this.ContainedElement.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.Parameter.AddRange(this.Parameter.Select(x => x.Clone(true)));
                clone.ParameterGroup.AddRange(this.ParameterGroup.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ElementDefinition"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ElementDefinition"/>.
        /// </returns>
        public new ElementDefinition Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ElementDefinition)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ElementDefinition"/>.
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
        /// Resolve the properties of the current <see cref="ElementDefinition"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ElementDefinition;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ElementDefinition POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.ContainedElement.ResolveList(dto.ContainedElement, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.Parameter.ResolveList(dto.Parameter, dto.IterationContainerId, this.Cache);
            this.ParameterGroup.ResolveList(dto.ParameterGroup, dto.IterationContainerId, this.Cache);
            this.ReferencedElement.ResolveList(dto.ReferencedElement, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ElementDefinition"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ElementDefinition(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.ContainedElement.AddRange(this.ContainedElement.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.Parameter.AddRange(this.Parameter.Select(x => x.Iid));
            dto.ParameterGroup.AddRange(this.ParameterGroup.Select(x => x.Iid));
            dto.ReferencedElement.AddRange(this.ReferencedElement.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
