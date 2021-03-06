﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOperationContainerException.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Exceptions
{
    using System;
    using CDP4Dal.Operations;

    /// <summary>
    /// A <see cref="InvalidOperationContainerException"/> is thrown when an <see cref="OperationContainer"/> is invalid or incomplete,
    /// or one of the contained <see cref="Operation"/>s is invalid or incomplete.
    /// </summary>
    public class InvalidOperationContainerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        public InvalidOperationContainerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InvalidOperationContainerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InvalidOperationContainerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
