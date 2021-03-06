﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeGenerator.cs" company="RHEA System  S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;   
    using System.Linq;    
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using NLog;
    
    /// <summary>
    /// The purpose of the <see cref="NestedElementTreeGenerator"/> class is to generate the <see cref="NestedElement"/>s
    /// and <see cref="NestedParameter"/>s for an <see cref="Option"/> where the <see cref="NestedParameter"/>s
    /// are owned by a specific <see cref="DomainOfExpertise"/>
    /// </summary>
    /// <remarks>
    /// The <see cref="NestedParameter"/>s represent the owned <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s,
    /// and <see cref="ParameterSubscription"/>s. Each <see cref="ParameterTypeComponent"/> of a <see cref="CompoundParameterType"/> is 
    /// represented by a unique <see cref="NestedParameter"/>.
    /// </remarks>
    public class NestedElementTreeGenerator
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        public IEnumerable<NestedElement> Generate(Option option, DomainOfExpertise domainOfExpertise)
        {
            if (option == null)
            {
                throw new ArgumentNullException("option", "The option may not be null");
            }

            if (domainOfExpertise == null)
            {
                throw new ArgumentNullException("domainOfExpertise", "The domainOfExpertise may not be null");
            }

            var iteration = (Iteration)option.Container;
            var rootElement = iteration.TopElement;
            
            if (rootElement == null)
            {
                throw new NestedElementTreeException(string.Format("The container Iteration of Option {0} does not have a TopElement specified", option.ShortName));
            }

            Logger.Debug($"Generating NestedElement for Iteration {iteration.Iid}, Option: {option.ShortName}, DomainOfExpertise {domainOfExpertise.ShortName}");

            var createNestedElements = this.GenerateNestedElements(option, domainOfExpertise, rootElement);
            return createNestedElements;
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        public IEnumerable<NestedElement> GenerateNestedElements(Option option, DomainOfExpertise domainOfExpertise, ElementDefinition rootElement)
        {
            if (option == null)
            {
                throw new ArgumentNullException("option", "The option may not be null");
            }

            if (domainOfExpertise == null)
            {
                throw new ArgumentNullException("domainOfExpertise", "The domainOfExpertise may not be null");
            }

            if (rootElement == null)
            {
                throw new ArgumentNullException("rootElement", "The rootElement may not be null");
            }

            var nestedElements = new List<NestedElement>();
            
            var rootNestedElement = this.CreateNestedElementAndNestedParametersForRootElement(rootElement, domainOfExpertise, option);            
            nestedElements.Add(rootNestedElement);
            
            var elementUsages = new List<ElementUsage>();
            var recursedNestedElements = this.RecursivelyCreateNestedElements(rootElement, rootElement, domainOfExpertise, elementUsages, option);
            nestedElements.AddRange(recursedNestedElements);

            return nestedElements;
        }

        /// <summary>
        /// Recursively Create <see cref="NestedElement"/>s
        /// </summary>
        /// <param name="elementDefinition">
        /// The <see cref="ElementDefinition"/> that contains <see cref="ElementUsage"/>s that
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that is the root of the <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="elementUsages">
        /// A <see cref="List{ElementUsage}"/> that contains the <see cref="ElementUsage"/> that define the containment tree
        /// for the <see cref="NestedElement"/>s at the level of the <paramref name="elementDefinition"/>.
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{NestedElement}"/> that have been created.
        /// </returns>
        private IEnumerable<NestedElement> RecursivelyCreateNestedElements(ElementDefinition elementDefinition, ElementDefinition rootElement, DomainOfExpertise domainOfExpertise, List<ElementUsage> elementUsages, Option option)
        {
            var cache = elementDefinition.Cache;
            var uri = elementDefinition.IDalUri;

            foreach (var elementUsage in elementDefinition.ContainedElement)
            {
                // comparison is done based on unique identifiers, not on object level. The provided option may be a clone
                if (elementUsage.ExcludeOption.Any(x => x.Iid == option.Iid))
                {
                    Logger.Debug($"ElementUsage {elementUsage.Iid}:{elementUsage.ShortName} is excluded from the Nested Elements.");
                    continue;
                }

                var nestedElement = new NestedElement(Guid.NewGuid(), cache, uri)
                                        {
                                            RootElement = rootElement,
                                            IsVolatile = true
                                        };
                option.NestedElement.Add(nestedElement);

                var nestedParameters = this.CreateNestedParameters(elementUsage, domainOfExpertise, option);
                foreach (var nestedParameter in nestedParameters)
                {
                    nestedElement.NestedParameter.Add(nestedParameter);
                }
                
                var containmentUsages = new List<ElementUsage>();
                foreach (var usage in elementUsages)
                {
                    nestedElement.ElementUsage.Add(usage);
                    containmentUsages.Add(usage);
                }

                nestedElement.ElementUsage.Add(elementUsage);               
                containmentUsages.Add(elementUsage);

                var referencedElementDefinition = elementUsage.ElementDefinition;

                var nestedElements = this.RecursivelyCreateNestedElements(referencedElementDefinition, rootElement, domainOfExpertise, containmentUsages, option);
                foreach (var element in nestedElements)
                {
                    yield return element;
                }

                yield return nestedElement;
            }
        }

        /// <summary>
        /// Creates The <see cref="NestedElement"/> and contained <see cref="NestedParameter"/> that represents the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that is the root of the <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{NestedElement}"/> that have been created.
        /// </returns>
        private NestedElement CreateNestedElementAndNestedParametersForRootElement(ElementDefinition rootElement, DomainOfExpertise domainOfExpertise, Option option)
        {
            var nestedElement = new NestedElement(Guid.NewGuid(), rootElement.Cache, rootElement.IDalUri)
            {
                RootElement = rootElement,
                IsVolatile = true,
                IsRootElement = true
            };
            option.NestedElement.Add(nestedElement);

            foreach (var parameter in rootElement.Parameter)
            {
                var compoundParameterType = parameter.ParameterType as CompoundParameterType;

                if (parameter.Owner == domainOfExpertise)
                {
                    var valueSets = parameter.IsOptionDependent ? parameter.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameter.ValueSet;

                    foreach (var parameterValueSet in valueSets)
                    {
                        if (compoundParameterType == null)
                        {
                            var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterValueSet);
                            nestedElement.NestedParameter.Add(nestedParameter);
                        }
                        else
                        {
                            foreach (var component in compoundParameterType.Component)
                            {
                                var comp = (ParameterTypeComponent)component;
                                var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterValueSet);
                                nestedElement.NestedParameter.Add(nestedParameter);
                            }
                        }
                    }
                }
                else
                {
                    var subscription = parameter.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);
                    if (subscription != null)
                    {
                        var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);
                        foreach (var nestedParameter in nestedParameters)
                        {
                            nestedElement.NestedParameter.Add(nestedParameter);
                        }
                    }
                }
            }

            return nestedElement;
        }

        /// <summary>
        /// Creates <see cref="NestedParameter"/>s based on the <see cref="Parameter"/> that are contained by the <see cref="ElementDefinition"/>
        /// that is referenced by the <paramref name="elementUsage"/> as well as <see cref="NestedParameter"/>s that are based on the <see cref="ParameterOverride"/>
        /// that are contained by the <paramref name="elementUsage"/> itself.
        /// </summary>
        /// <param name="elementUsage">
        /// The <see cref="ElementUsage"/> that corresponds to the <see cref="NestedElement"/> for which <see cref="NestedParameter"/>s need to be created
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. 
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/>.
        /// </returns>
        private IEnumerable<NestedParameter> CreateNestedParameters(ElementUsage elementUsage, DomainOfExpertise domainOfExpertise, Option option)
        {
            var elementDefinition = elementUsage.ElementDefinition;

            foreach (var parameter in elementDefinition.Parameter)
            {
                var compoundParameterType = parameter.ParameterType as CompoundParameterType;

                var parameterOveride = elementUsage.ParameterOverride.SingleOrDefault(po => po.Parameter == parameter);
                if (parameterOveride == null)
                {
                    if (parameter.Owner == domainOfExpertise)
                    {
                        var valueSets = parameter.IsOptionDependent ? parameter.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameter.ValueSet;

                        foreach (var parameterValueSet in valueSets)
                        {
                            if (compoundParameterType == null)
                            {
                                var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterValueSet);
                                yield return nestedParameter;
                            }
                            else
                            {
                                foreach (var component in compoundParameterType.Component)
                                {
                                    var comp = (ParameterTypeComponent)component;
                                    var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterValueSet);
                                    yield return nestedParameter;
                                }
                            }
                        }
                    }
                    else
                    {
                        var subscription = parameter.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);
                        if (subscription != null)
                        {
                            var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);
                            foreach (var nestedParameter in nestedParameters)
                            {
                                yield return nestedParameter;
                            }
                        }
                    }                    
                }
                else
                {
                    if (parameterOveride.Owner == domainOfExpertise)
                    {
                        var valueSets = parameterOveride.IsOptionDependent ? parameterOveride.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameterOveride.ValueSet;                        
                        foreach (var parameterOverrideValueSet in valueSets)
                        {
                            if (compoundParameterType == null)
                            {
                                var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterOverrideValueSet);
                                yield return nestedParameter;
                            }
                            else
                            {
                                foreach (var component in compoundParameterType.Component)
                                {
                                    var comp = (ParameterTypeComponent)component;
                                    var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterOverrideValueSet);
                                    yield return nestedParameter;
                                }
                            }
                        }
                    }
                    else
                    {
                        var subscription = parameterOveride.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);
                        if (subscription != null)
                        {
                            var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);
                            foreach (var nestedParameter in nestedParameters)
                            {
                                yield return nestedParameter;
                            }                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="subscription">
        /// The <see cref="ParameterSubscription"/> that contains the <see cref="ParameterSubscriptionValueSet"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. 
        /// </param>
        /// <param name="compoundParameterType">
        /// The <see cref="CompoundParameterType"/> that contains the <see cref="ParameterTypeComponent"/> for which distinct <see cref="NestedParameter"/>
        /// are created.
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private IEnumerable<NestedParameter> CreatedNestedParameters(ParameterSubscription subscription, Option option, CompoundParameterType compoundParameterType)
        {
            var valueSets = subscription.IsOptionDependent ? subscription.ValueSet.Where(vs => vs.ActualOption == option).ToList() : subscription.ValueSet;
            foreach (var parameterSubscriptionValueSet in valueSets)
            {
                if (compoundParameterType == null)
                {
                    var nestedParameter = this.CreateNestedParameter(subscription, null, parameterSubscriptionValueSet);
                    yield return nestedParameter;
                }
                else
                {
                    foreach (var component in compoundParameterType.Component)
                    {
                        var comp = (ParameterTypeComponent)component;
                        var nestedParameter = this.CreateNestedParameter(subscription, comp, parameterSubscriptionValueSet);
                        yield return nestedParameter;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="parameter">
        /// The <see cref="ParameterOrOverrideBase"/> that contains the <see cref="ParameterValueSetBase"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="component">
        /// The <see cref="ParameterTypeComponent"/> that this <see cref="NestedParameter"/> is associated to. This may be null in case the <see cref="ParameterType"/>
        /// of the associated <see cref="Parameter"/> is a <see cref="ScalarParameterType"/>.
        /// </param>
        /// <param name="valueSet">
        /// The <see cref="ParameterValueSetBase"/> that provides the reference to the <see cref="ActualFiniteState"/> and values
        /// to create the <see cref="NestedParameter"/>
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private NestedParameter CreatedNestedParameter(ParameterOrOverrideBase parameter, ParameterTypeComponent component, ParameterValueSetBase valueSet)
        {
            var componentIndex = component == null ? 0 : component.Index;
            var actualValue = valueSet.ActualValue[componentIndex];
            var formula = valueSet.Formula[componentIndex];

            var nestedParameter = new NestedParameter(Guid.NewGuid(), parameter.Cache, parameter.IDalUri)
            {
                IsVolatile = true,
                AssociatedParameter = parameter,
                Owner = parameter.Owner,
                Component = component,
                ActualState = valueSet.ActualState,
                ActualValue = actualValue,
                Formula = formula
            };

            return nestedParameter;
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="subscription">
        /// The <see cref="ParameterSubscription"/> that contains the <see cref="ParameterSubscriptionValueSet"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="component">
        /// The <see cref="ParameterTypeComponent"/> that this <see cref="NestedParameter"/> is associated to. This may be null in case the <see cref="ParameterType"/>
        /// of the associated <see cref="Parameter"/> is a <see cref="ScalarParameterType"/>.
        /// </param>
        /// <param name="valueSet">
        /// The <see cref="ParameterSubscriptionValueSet"/> that provides the reference to the <see cref="ActualFiniteState"/> and values
        /// to create the <see cref="NestedParameter"/>
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private NestedParameter CreateNestedParameter(ParameterSubscription subscription, ParameterTypeComponent component, ParameterSubscriptionValueSet valueSet)
        {
            var componentIndex = component == null ? 0 : component.Index;
            var actualValue = valueSet.ActualValue[componentIndex];
            
            var nestedParameter = new NestedParameter(Guid.NewGuid(), subscription.Cache, subscription.IDalUri)
            {
                IsVolatile = true,
                AssociatedParameter = subscription,
                Owner = subscription.Owner,
                Component = component,
                ActualState = valueSet.ActualState,
                ActualValue = actualValue,
            };

            return nestedParameter;
        }
    }
}
