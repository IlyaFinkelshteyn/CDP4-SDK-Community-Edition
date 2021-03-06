// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramElementContainer.cs" company="RHEA System S.A.">
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
    using System.Xml.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="DiagramElementContainer"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    public abstract partial class DiagramElementContainer : DiagramThingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementContainer"/> class.
        /// </summary>
        protected DiagramElementContainer()
        {
            this.Bounds = new List<Guid>();
            this.DiagramElement = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementContainer"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected DiagramElementContainer(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Bounds = new List<Guid>();
            this.DiagramElement = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Bounds instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Bounds { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DiagramElement instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> DiagramElement { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagramElementContainer"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Bounds);
                containers.Add(this.DiagramElement);
                return containers;
            }
        }
    }
}
