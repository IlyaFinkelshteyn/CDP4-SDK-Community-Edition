// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="RequirementsContainer"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class RequirementsContainer : DefinedThing, ICategorizableThing, IOwnedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementsContainer"/> class.
        /// </summary>
        protected RequirementsContainer()
        {
            this.Category = new List<Guid>();
            this.Group = new List<Guid>();
            this.ParameterValue = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementsContainer"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected RequirementsContainer(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Category = new List<Guid>();
            this.Group = new List<Guid>();
            this.ParameterValue = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced Category instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Category { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Group instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Group { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid Owner { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ParameterValue instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ParameterValue { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="RequirementsContainer"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Group);
                containers.Add(this.ParameterValue);
                return containers;
            }
        }
    }
}
