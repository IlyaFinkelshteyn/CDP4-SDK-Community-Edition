﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using System;

    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="OptionComparer"/>
    /// </summary>    
    [TestFixture]
    public class OptionComparerTestFixture
    {
        private Iteration iteration;

        private Option optiona;

        private Option optionb;

        [SetUp]
        public void SetUp()
        {
            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.optiona = new Option(Guid.NewGuid(), null, null) { Name = "option a", ShortName = "optionb" };
            this.optionb = new Option(Guid.NewGuid(), null, null) { Name = "option b", ShortName = "optionb" };
            this.iteration.Option.Add(this.optionb);
            this.iteration.Option.Add(this.optiona);
        }

        [Test]
        public void verifyThatOptionDependentValuesetsComparerCompareReturnsExpectedResults()
        {
            var comparer = new OptionComparer();

            Assert.AreEqual(0, comparer.Compare(null, null));

            Assert.AreEqual(1, comparer.Compare(null, this.optiona));

            Assert.AreEqual(-1, comparer.Compare(this.optiona, null));

            var comparisonab = comparer.Compare(this.optiona, this.optionb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(this.optionb, this.optiona);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(this.optiona, this.optiona);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(this.optionb, this.optionb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatOptionsContainedInDifferentIterationsThrowsException()
        {
            var comparer = new OptionComparer();

            var iterationx = new Iteration(Guid.NewGuid(), null, null);
            var optionx = new Option(Guid.NewGuid(), null, null);

            iterationx.Option.Add(optionx);

            var iterationy = new Iteration(Guid.NewGuid(), null, null);
            var optiony = new Option(Guid.NewGuid(), null, null);

            iterationy.Option.Add(optiony);

            Assert.Throws<InvalidOperationException>(() => comparer.Compare(optionx, optiony));
        }
    }
}
