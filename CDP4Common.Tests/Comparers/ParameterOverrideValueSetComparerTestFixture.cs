﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetComparerTestFixture.cs" company="RHEA System S.A.">
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
    /// Suite of tests for the <see cref="ParameterOverrideValueSetComparer"/> class
    /// </summary>
    [TestFixture]
    public class ParameterOverrideValueSetComparerTestFixture
    {
        private Iteration iteration;

        private Option optiona;

        private Option optionb;

        private ActualFiniteState actualFiniteStatea;

        private ActualFiniteState actualFiniteStateb;

        [SetUp]
        public void SetUp()
        {
            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.optiona = new Option(Guid.NewGuid(), null, null) { Name = "option a", ShortName = "optionb" };
            this.optionb = new Option(Guid.NewGuid(), null, null) { Name = "option b", ShortName = "optionb" };
            this.iteration.Option.Add(this.optionb);
            this.iteration.Option.Add(this.optiona);

            var possibleFiniteStateList = new PossibleFiniteStateList(Guid.NewGuid(), null, null);
            var possibleFiniteStatea = new PossibleFiniteState(Guid.NewGuid(), null, null)
            {
                Name = "state a",
                ShortName = "statea"
            };
            var possibleFiniteStateb = new PossibleFiniteState(Guid.NewGuid(), null, null)
            {
                Name = "state b",
                ShortName = "stateb"
            };
            possibleFiniteStateList.PossibleState.Add(possibleFiniteStateb);
            possibleFiniteStateList.PossibleState.Add(possibleFiniteStatea);
            this.iteration.PossibleFiniteStateList.Add(possibleFiniteStateList);

            var actualFiniteStateList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualFiniteStatea = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualFiniteStatea.PossibleState.Add(possibleFiniteStatea);
            this.actualFiniteStateb = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualFiniteStateb.PossibleState.Add(possibleFiniteStateb);
            actualFiniteStateList.ActualState.Add(this.actualFiniteStateb);
            actualFiniteStateList.ActualState.Add(this.actualFiniteStatea);
            this.iteration.ActualFiniteStateList.Add(actualFiniteStateList);
        }

        [Test]
        public void verifyThatOptionDependentValuesetsComparerCompareReturnsExpectedResults()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSeta = new ParameterValueSet();
            var parameterValueSetb = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSeta);
            parameter.ValueSet.Add(parameterValueSetb);

            parameterValueSeta.ActualOption = this.optiona;
            parameterValueSetb.ActualOption = this.optionb;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;
            
            var parameterOverrideValueSeta = new ParameterOverrideValueSet();
            parameterOverrideValueSeta.ParameterValueSet = parameterValueSeta;

            var optiondepaparametervaluesetb = new ParameterOverrideValueSet();
            optiondepaparametervaluesetb.ParameterValueSet = parameterValueSetb;

            var comparer = new ParameterOverrideValueSetComparer();
            var comparisonab = comparer.Compare(parameterOverrideValueSeta, optiondepaparametervaluesetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(optiondepaparametervaluesetb, parameterOverrideValueSeta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSeta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(optiondepaparametervaluesetb, optiondepaparametervaluesetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSeta = new ParameterValueSet();
            var parameterValueSetb = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSeta);
            parameter.ValueSet.Add(parameterValueSetb);

            parameterValueSeta.ActualState = this.actualFiniteStatea;
            parameterValueSetb.ActualState = this.actualFiniteStateb;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;

            var parameterOverrideValueSeta = new ParameterOverrideValueSet();
            parameterOverrideValueSeta.ParameterValueSet = parameterValueSeta;

            var parameterOverrideValueSetb = new ParameterOverrideValueSet();
            parameterOverrideValueSetb.ParameterValueSet = parameterValueSetb;

            var comparer = new ParameterOverrideValueSetComparer();
            var comparisonab = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSetb);
            Assert.AreEqual(1, comparisonab);

            var comparisonba = comparer.Compare(parameterOverrideValueSetb, parameterOverrideValueSeta);
            Assert.AreEqual(-1, comparisonba);

            var comparisonaa = comparer.Compare(parameterOverrideValueSeta, parameterOverrideValueSeta);
            Assert.AreEqual(0, comparisonaa);

            var comparisonbb = comparer.Compare(parameterOverrideValueSetb, parameterOverrideValueSetb);
            Assert.AreEqual(0, comparisonbb);
        }

        [Test]
        public void VerifyThatOptionDepStateFullValueSetsComparerCompareReturnsExpectedResults()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.IsOptionDependent = true;
            var parameterValueSetaa = new ParameterValueSet();
            var parameterValueSetab = new ParameterValueSet();
            var parameterValueSetbb = new ParameterValueSet();
            var parameterValueSetba = new ParameterValueSet();
            parameter.ValueSet.Add(parameterValueSetaa);
            parameter.ValueSet.Add(parameterValueSetab);
            parameter.ValueSet.Add(parameterValueSetbb);
            parameter.ValueSet.Add(parameterValueSetba);

            parameterValueSetaa.ActualOption = this.optiona;
            parameterValueSetaa.ActualState = this.actualFiniteStatea;

            parameterValueSetab.ActualOption = this.optiona;
            parameterValueSetab.ActualState = this.actualFiniteStateb;

            parameterValueSetbb.ActualOption = this.optionb;
            parameterValueSetbb.ActualState = this.actualFiniteStateb;

            parameterValueSetba.ActualOption = this.optionb;
            parameterValueSetba.ActualState = this.actualFiniteStatea;

            var parameterOverride = new ParameterOverride();
            parameterOverride.Parameter = parameter;

            var aa = new ParameterOverrideValueSet();
            aa.ParameterValueSet = parameterValueSetaa;

            var ab = new ParameterOverrideValueSet();
            ab.ParameterValueSet = parameterValueSetab;

            var bb = new ParameterOverrideValueSet();
            bb.ParameterValueSet = parameterValueSetbb;

            var ba = new ParameterOverrideValueSet();
            ba.ParameterValueSet = parameterValueSetba;

            var comparer = new ParameterOverrideValueSetComparer();

            var comparison_aa_ab = comparer.Compare(aa, ab);
            Assert.AreEqual(1, comparison_aa_ab);

            var comparison_aa_bb = comparer.Compare(aa, ab);
            Assert.AreEqual(1, comparison_aa_bb);
        }
    }
}
