// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConversionBasedUnit.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="ConversionBasedUnit"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public abstract partial class ConversionBasedUnit : MeasurementUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionBasedUnit"/> class.
        /// </summary>
        protected ConversionBasedUnit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionBasedUnit"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ConversionBasedUnit(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the ConversionFactor.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string ConversionFactor { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ReferenceUnit.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid ReferenceUnit { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ConversionBasedUnit"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
