﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerList.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Types
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    /// <summary>
    /// List Type used for the 10-25 model for classes which are part of a composition relationship
    /// </summary>
    /// <typeparam name="T">the type of <see cref="Thing"/> that this List contains</typeparam>
    public class ContainerList<T> : List<T> where T : Thing
    {
        /// <summary>
        /// backing field for the container of this <see cref="ContainerList{T}"/>
        /// </summary>
        private readonly Thing container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class
        /// </summary>
        /// <param name="container">the <see cref="Thing"/> that contains this <see cref="ContainerList{T}"/></param>
        public ContainerList(Thing container)
        {
            this.container = container;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerList{T}"/> class
        /// </summary>
        /// <param name="containerList">
        /// The <see cref="ContainerList{T}"/> which values are copied.
        /// </param>
        /// <param name="container">
        /// The owner of this <see cref="ContainerList{T}"/>.
        /// </param>
        /// <param name="updateContaineeContainer">
        /// A value indicating whether the container of the contained items, the containees, in the provided <paramref name="containerList"/>
        /// shall be set to the provided <paramref name="container"/>. The default value = false
        /// </param>
        public ContainerList(ContainerList<T> containerList, Thing container, bool updateContaineeContainer = false) : base (containerList)
        {
            this.container = container;

            if (updateContaineeContainer)
            {
                foreach (var item in containerList)
                {
                    item.Container = this.container;
                }
            }
        }

        /// <summary>
        /// Adds a new <see cref="Thing"/> in the <see cref="List{T}"/> and sets its <see cref="Thing.Container"/> property
        /// </summary>
        /// <param name="thing">the new <see cref="Thing"/> to add</param>
        public new void Add(T thing)
        {
            thing.Container = this.container;

            if (this.Contains(thing))
            {
                throw new InvalidOperationException(string.Format("The added item already exists {0}.", thing.Iid));
            }

            base.Add(thing);
        }

        /// <summary>
        /// Adds a <see cref="IEnumerable{T}"/> of <see cref="Thing"/> in the <see cref="List{T}"/> and sets their <see cref="Thing.Container"/> property
        /// </summary>
        /// <param name="things">the new <see cref="Thing"/>s to add</param>
        public new void AddRange(IEnumerable<T> things)
        {
            foreach (var thing in things)
            {
                this.Add(thing);
            }
        }

        /// <summary>
        /// Gets or sets the value of the <see cref="Thing"/> associated with the specified index.
        /// </summary>
        /// <param name="index">the index</param>
        /// <returns>The <see cref="Thing"/> with the specified index (only for get).</returns>
        public new T this[int index]
        {
            get
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "index", string.Format("index is {0}, valid range is 0 to {1}", index, this.Count - 1));
                }

                return base[index];
            }

            set
            {
                if (index < 0 || index >= base.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "index", string.Format("index is {0}, valid range is 0 to {1}", index, this.Count - 1));
                }

                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                
                if (this.Contains(value) && base[index] != value)
                {
                    throw new InvalidOperationException(string.Format("The added item already exists {0}.", value.Iid));
                }

                value.Container = this.container;
                base[index] = value;
            }
        }
    }
}