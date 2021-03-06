﻿// -------------------------------------------------------------------------------------------------
// <copyright file="IThingTransaction.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Dal.Operations
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    /// <summary>
    /// The interface <see cref="Thing"/> operations
    /// </summary>
    public interface IThingTransaction
    {
        /// <summary>
        /// Gets the Added <see cref="Thing"/>s
        /// </summary>
        IEnumerable<Thing> AddedThing { get; }

        /// <summary>
        /// Gets the deleted <see cref="Thing"/>s
        /// </summary>
        IEnumerable<Thing> DeletedThing { get; }

        /// <summary>
        /// Gets the Updated <see cref="Thing"/>s where the Key is the original <see cref="Thing"/> and the value the cloned <see cref="Thing"/>
        /// </summary>
        IReadOnlyDictionary<Thing, Thing> UpdatedThing { get; }

        /// <summary>
        /// Gets the copied <see cref="Thing"/>s
        /// </summary>
        IReadOnlyDictionary<Tuple<Thing, Thing>, OperationKind> CopiedThing { get; }

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created in the current transaction along with all its potential contained <see cref="Thing"/>s
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to create
        /// </param>
        /// <param name="containerClone">
        /// The clone of the container in which <paramref name="clone"/> is added. 
        /// <remarks>
        /// <paramref name="containerClone"/> is only updated in the context where there are no sub-transaction.
        /// </remarks>
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a <see cref="TopContainer"/> or <see cref="Iteration"/> is registered
        /// </exception>
        void CreateDeep(Thing clone, Thing containerClone = null);

        /// <summary>
        /// Register a deep copy operations for the <see cref="Thing"/>
        /// </summary>
        /// <param name="deepClone">The <see cref="Thing"/> to copy</param>
        /// <param name="containerClone">The container</param>
        void CopyDeep(Thing deepClone, Thing containerClone = null);

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created in the current transaction
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to create
        /// </param>
        /// <param name="containerClone">
        /// The clone of the container in which <paramref name="clone"/> is added. 
        /// <remarks>
        /// <paramref name="containerClone"/> is only updated in the context where there are no sub-transaction.
        /// </remarks>
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a <see cref="TopContainer"/> or <see cref="Iteration"/> is registered
        /// </exception>
        void Create(Thing clone, Thing containerClone = null);

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created or updated in the current transaction
        /// </summary>
        /// <param name="clone">The clone of the <see cref="Thing"/></param>
        void CreateOrUpdate(Thing clone);

        /// <summary>
        /// Creates a <see cref="Thing"/> deletion operation
        /// </summary>
        /// <param name="thing">The clone of the <see cref="Thing"/> to delete</param>
        /// <param name="containerClone">The clone of the container (mandatory in dialogs)</param>
        void Delete(Thing thing, Thing containerClone = null);

        /// <summary>
        /// Registers the provided clone of a <see cref="Thing"/> as a copy with its destination
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to copy
        /// </param>
        /// <param name="containerDestinationClone">
        /// The new container
        /// </param>
        /// <param name="operationKind">
        /// The <see cref="OperationKind"/> that specify the kind of copy operation
        /// </param>
        void Copy(Thing clone, Thing containerDestinationClone, OperationKind operationKind);

        /// <summary>
        /// Registers the provided clone of a <see cref="Thing"/> as a copy
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> to copy</param>
        /// <param name="operationKind">
        /// The <see cref="OperationKind"/> that specify the kind of copy operation
        /// </param>
        void Copy(Thing clone, OperationKind operationKind);

        /// <summary>
        /// Finalize the sub-transaction by updating all the containing <see cref="Thing"/>s
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> to update</param>
        /// <param name="containerclone">The new container of <paramref name="clone"/></param>
        /// <param name="nextThing">
        /// The next (following) <see cref="Thing"/> in an <see cref="OrderedItemList{T}"/> where the new <see cref="Thing"/> is created
        /// if <paramref name="nextThing"/> is null, the <paramref name="clone"/> is appended to the list
        /// </param>
        void FinalizeSubTransaction(Thing clone, Thing containerclone, Thing nextThing = null);

        /// <summary>
        /// Get the clone of the <see cref="Thing"/> used in the current <see cref="IThingTransaction"/>
        /// </summary>
        /// <param name="thing">The original <see cref="Thing"/></param>
        /// <returns>The clone of the <see cref="Thing"/></returns>
        Thing GetClone(Thing thing);

        /// <summary>
        /// Get the last clone of a specified <see cref="Thing"/> with a specific id in the current chain of operations
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>The last clone created if any, null otherwise</returns>
        Thing GetLastCloneCreated(Thing thing);

        /// <summary>
        /// Finalizes all operations that happened during this <see cref="IThingTransaction"/>
        /// </summary>
        /// <returns>The <see cref="OperationContainer"/></returns>
        OperationContainer FinalizeTransaction();
    }
}