﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HeaderException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A <see cref="HeaderException"/> is thrown the when a specific header was not found in a REST response
    /// or if is found it has an incorrect value 
    /// </summary>
    public class HeaderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderException"/> class.
        /// </summary>
        public HeaderException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public HeaderException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public HeaderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
