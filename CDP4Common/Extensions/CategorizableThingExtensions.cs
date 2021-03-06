﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategorizableThingExtensions.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// Extension methods for <see cref="ICategorizableThing"/>
    /// </summary>
    public static class CategorizableThingExtensions
    {
        /// <summary>
        /// Queries the <see cref="ICategorizableThing"/> and checks whether it is a member of the 
        /// supplied <see cref="Category"/>, this includes membership of the sub <see cref="Category"/> instances
        /// of the provided <see cref="Category"/>
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> instance that is being queried.
        /// </param>
        /// <param name="category">
        /// The <see cref="Category"/> that the <see cref="ICategorizableThing"/> may be a member of.
        /// </param>
        /// <returns>
        /// returns true if the <see cref="ICategorizableThing"/> is a member of the <paramref name="category"/>, including it's 
        /// sub <see cref="Category"/> instances. Returns false if the <see cref="ICategorizableThing"/> is not a member
        /// of the <paramref name="category"/> nor any of it's sub <see cref="Category"/> instances.
        /// </returns>
        public static bool IsMemberOfCategory(this ICategorizableThing categorizableThing, Category category)
        {
            var memberOfCategories = categorizableThing.GetAllCategories();

            var categoriesToCheck = category.AllDerivedCategories().ToList();
            categoriesToCheck.Add(category);

            foreach (var memberOfCategory in memberOfCategories)
            {
                if (categoriesToCheck.Contains(memberOfCategory))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries all the super categories of the categories of an <see cref="ICategorizableThing"/>
        /// and returns the categories and all the super categories up the inheritance chain.
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> that is to be queried for all its categories and its super categories.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Category}"/> that contains all the categories
        /// </returns>
        /// <remarks>
        /// If the <paramref name="categorizableThing"/> is an <see cref="ElementUsage"/> the returned <see cref="Category"/> instances
        /// include those of the referenced <see cref="ElementDefinition"/>
        /// </remarks>
        public static IEnumerable<Category> GetAllCategories(this ICategorizableThing categorizableThing)
        {
            var allCategories = new List<Category>();

            var elementUsage = categorizableThing as ElementUsage;
            if (elementUsage != null)
            {
                var elementDefinition = elementUsage.ElementDefinition;
                if (elementDefinition != null)
                {
                    allCategories.AddRange(elementDefinition.Category); 
                }
            }

            allCategories.AddRange(categorizableThing.Category);

            foreach (var category in allCategories)
            {
                foreach (var c in category.AllSuperCategories())
                {
                    yield return c;
                }

                yield return category;
            }
        }

        /// <summary>
        /// Queries all the super categories of the categories of an <see cref="ICategorizableThing"/>
        /// and returns the categories and all the super categories up the inheritance chain.
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> that is to be queried for all its categories and its super categories.
        /// </param>
        /// <returns>
        /// the short names of the categories and super categories concatenated as a string
        /// </returns>
        public static string GetAllCategoryShortNames(this ICategorizableThing categorizableThing)
        {
            var allCategories = categorizableThing.GetAllCategories();
            return allCategories.Aggregate(string.Empty, (current, cat) => string.Format("{0} {1}", current, cat.ShortName)).Trim();
        }
    }
}