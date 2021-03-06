﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoFactory.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    public static class ClasslessDtoFactory
    {
        /// <summary>
        /// Given a <see cref="List{T}"/> of properties to add, populate this plain DTO from a <see cref="CDP4Common.DTO.Thing"/>. The Iid and Classkind are populated automatically and thus
        /// do not require to be entered into the <see cref="propertyList"/> variable. If <see cref="propertyList"/> is null then only the Iid and ClassKind are passed.
        /// </summary>
        /// <typeparam name="T">
        /// Of type <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// The <see cref="Thing"/>, properties of which to use to populate this DTO with.
        /// </param>
        /// <param name="propertyList">
        /// The list of names of property names to use to filter. Can be null to produce the simplest form with just Id and ClassKind
        /// </param>
        /// <returns>
        /// The <see cref="ClasslessDTO"/>.
        /// </returns>
        public static ClasslessDTO FromThing<T>(IMetaDataProvider metaDataProvider, T thing, IEnumerable<string> propertyList = null) where T : Thing
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var classlesdto = new ClasslessDTO();

            // the Iid and ClassKind properties are transferred automatically
            classlesdto.Add("ClassKind", thing.ClassKind);
            classlesdto.Add("Iid", thing.Iid);
            var metainfo = metaDataProvider.GetMetaInfo(thing.ClassKind.ToString());

            // all other named properties
            if (propertyList != null)
            {
                foreach (var property in propertyList)
                {
                    // If Iid somehow gets included into the list just skip it
                    if (property.Equals("Iid") || property.Equals("ClassKind"))
                    {
                        continue;
                    }

                    var propertyMetadata = metainfo.GetPropertyMetaInfo(property);
                    if (!propertyMetadata.IsDerived && propertyMetadata.IsDataMember)
                    {
                        var propertyValue = metainfo.GetValue(property, thing);
                        if (propertyValue == null && !propertyMetadata.IsNullable)
                        {
                            propertyValue = string.Empty;
                        }

                        classlesdto.Add(property, propertyValue);
                    }
                }
            }

            return classlesdto;
        }

        /// <summary>
        /// The full <see cref="ClasslessDTO"/> from thing.
        /// </summary>
        /// <param name="thing">
        /// The thing.
        /// </param>
        /// <typeparam name="T">
        /// Of type <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// The <see cref="ClasslessDTO"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If the provided <see cref="Thing"/> is null this exception is thrown.
        /// </exception>
        public static ClasslessDTO FullFromThing<T>(IMetaDataProvider metaDataProvider, T thing) where T : Thing
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var classlesdto = new ClasslessDTO();

            // the Iid and ClassKind properties are transferred automatically
            classlesdto.Add("ClassKind", thing.ClassKind);
            classlesdto.Add("Iid", thing.Iid);
            var metainfo = metaDataProvider.GetMetaInfo(thing.ClassKind.ToString());

            foreach (var property in metainfo.GetPropertyNameCollection())
            {
                var propertyMetadata = metainfo.GetPropertyMetaInfo(property);
                if (property.Equals("Iid") || property.Equals("ClassKind") || propertyMetadata.IsDerived || !propertyMetadata.IsDataMember)
                {
                    continue;
                }

                var propertyValue = metainfo.GetValue(property, thing);
                if (propertyValue == null && !propertyMetadata.IsNullable)
                {
                    propertyValue = string.Empty;
                }

                classlesdto.Add(property, propertyValue);
            }

            return classlesdto;
        }
    }
}