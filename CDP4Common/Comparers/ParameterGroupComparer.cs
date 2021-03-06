﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroupComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The <see cref="IComparer{T}"/> used to sort <see cref="ParameterGroup"/> from its Name
    /// </summary>
    public class ParameterGroupComparer : IComparer<ParameterGroup>
    {
        /// <summary>
        /// Compares two <see cref="ParameterGroup"/> and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first <see cref="ParameterGroup"/></param>
        /// <param name="y">The second <see cref="ParameterGroup"/></param>
        /// <returns>
        /// Less than zero : x is less than y. 
        /// Zero: x equals y. 
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(ParameterGroup x, ParameterGroup y)
        {
            return System.String.Compare(x.Name, y.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}