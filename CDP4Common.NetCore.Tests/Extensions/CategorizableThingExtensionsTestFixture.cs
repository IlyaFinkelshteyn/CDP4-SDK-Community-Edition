﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategorizableThingExtensionsTestFixture.cs" company="RHEA Systen S.A.">
//   Copyright (c) 2017 RHEA Systen S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Extensions
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;    
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CategorizableThingExtensions"/> class
    /// </summary>
    [TestFixture]
    public class CategorizableThingExtensionsTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;

        private Category productCategory;
        private Category equipmentCategory;
        private Category batteryCategory;
        private Category lithiumBatteryCategory;
        private Category transmitterCategory;

        private ElementDefinition elementDefinition;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.productCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "PROD", Name = "Product" };
            this.equipmentCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "EQT", Name = "Equipment" };
            this.batteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "BAT", Name = "Battery" };
            this.lithiumBatteryCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "LITBAT", Name = "Lithium Battery" };
            this.transmitterCategory = new Category(Guid.NewGuid(), this.cache, this.uri) { ShortName = "TX", Name = "Transmitter" };

            this.lithiumBatteryCategory.SuperCategory.Add(this.batteryCategory);
            this.batteryCategory.SuperCategory.Add(this.equipmentCategory);
            this.transmitterCategory.SuperCategory.Add(this.equipmentCategory);
            this.equipmentCategory.SuperCategory.Add(this.productCategory);

            var lazyProductCategory = new Lazy<Thing>(() => this.productCategory);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.productCategory.Iid, null), lazyProductCategory);

            var lazyEquipmentCategory = new Lazy<Thing>(() => this.equipmentCategory);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.equipmentCategory.Iid, null), lazyEquipmentCategory);

            var lazyBatteryCategory = new Lazy<Thing>(() => this.batteryCategory);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.batteryCategory.Iid, null), lazyBatteryCategory);

            var lazyLithiumBatteryCategory = new Lazy<Thing>(() => this.lithiumBatteryCategory);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.lithiumBatteryCategory.Iid, null), lazyLithiumBatteryCategory);

            var lazyTransmitterCategory = new Lazy<Thing>(() => this.transmitterCategory);
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.transmitterCategory.Iid, null), lazyTransmitterCategory);

            this.elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
        }

        [Test]
        public void VerifyThatAllCategoriesAreReturned()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            var categories = this.elementDefinition.GetAllCategories();

            CollectionAssert.Contains(categories, this.productCategory);
            CollectionAssert.Contains(categories, this.equipmentCategory);
        }

        [Test]
        public void VerifyThatIfCategorizableThingIsElementUsageTheCategoriesOfTheReferencedElementDefinitionAreReturnedAsWell()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            var elementUsage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri);
            elementUsage.ElementDefinition = this.elementDefinition;

            var categories = elementUsage.GetAllCategories();

            CollectionAssert.Contains(categories, this.productCategory);
            CollectionAssert.Contains(categories, this.equipmentCategory);
        }

        [Test]
        public void VerifytThatAllCategoryShortNamesAreReturned()
        {
            this.elementDefinition.Category.Add(this.equipmentCategory);

            Assert.AreEqual("PROD EQT", this.elementDefinition.GetAllCategoryShortNames());
        }

        [Test]
        public void VerfifyThatIfCategorizableThingIsAMemberOfACategoryTrueIsReturned()
        {
            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            battery.Category.Add(this.batteryCategory);

            Assert.IsTrue(battery.IsMemberOfCategory(this.batteryCategory));
            Assert.IsTrue(battery.IsMemberOfCategory(this.equipmentCategory));
            Assert.IsTrue(battery.IsMemberOfCategory(this.productCategory));
        }

        [Test]
        public void VerfifyThatIfCategorizableThingIsANotMemberOfACategoryFalseIsReturned()
        {
            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            battery.Category.Add(this.batteryCategory);

            Assert.IsFalse(battery.IsMemberOfCategory(this.lithiumBatteryCategory));
            Assert.IsFalse(battery.IsMemberOfCategory(this.transmitterCategory));
        }
    }
}
