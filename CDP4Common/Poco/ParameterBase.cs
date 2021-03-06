﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterGroup"/>
    /// </summary>
    public partial class ParameterBase : IModelCode
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.ModelCode(); }
        }

        /// <summary>
        /// Gets the user-friendly shortname
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ModelCode(); }
        }

        /// <summary>
        /// Queries the grouping level of the current <see cref="ParameterBase"/>.
        /// </summary>
        /// <returns>
        /// The level of the <see cref="ParameterBase"/> in it's virtual <see cref="ParameterGroup"/> containment hierarchy.
        /// </returns>
        /// <remarks>
        /// The level of a <see cref="ParameterBase"/> that has no <see cref="Group"/> is zero.
        /// </remarks>
        public int Level()
        {
            if (this.Group == null)
            {
                return 0;
            }

            return this.Group.Level() + 1;
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the required <see cref="ReferenceDataLibrary"/> 
        /// for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                requiredRdls.UnionWith(this.ParameterType.RequiredRdls);
                return requiredRdls;
            }
        }

        /// <summary>
        /// Gets the <see cref="IValueSet"/> for this <see cref="ParameterBase"/>
        /// </summary>
        /// <remarks>
        /// This is a convenience property that simply returns the actual value-sets of the concrete <see cref="ParameterBase"/>
        /// ie, <see cref="Parameter.ValueSet"/>, <see cref="ParameterOverride.ValueSet"/> or <see cref="Parameter.ValueSet"/>
        /// </remarks>
        public IEnumerable<IValueSet> ValueSets
        {
            get
            {
                var parameter = this as Parameter;
                if (parameter != null)
                {
                    return parameter.ValueSet;
                }

                var parameterOverride = this as ParameterOverride;
                if (parameterOverride != null)
                {
                    return parameterOverride.ValueSet;
                }

                var subscription = (ParameterSubscription)this;
                return subscription.ValueSet;
            }
        }

        /// <summary>
        /// Computes the model code of the current object
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> that represents the model code, valid separators are <code>.</code> and <code>/</code>
        /// </returns>
        public abstract string ModelCode(int? componentIndex = null);
    }
}
