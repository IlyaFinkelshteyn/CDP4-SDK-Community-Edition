// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationMetaInfo.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated MetaInfo class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Common.Validation;

    /// <summary>
    /// This a class that holds meta info for <see cref="Iteration"/>.
    /// </summary>
    public partial class IterationMetaInfo : IIterationMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.Iteration, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Iteration, IEnumerable<Guid>>>
        {
            { "ActualFiniteStateList", iteration => iteration.ActualFiniteStateList },
            { "DiagramCanvas", iteration => iteration.DiagramCanvas },
            { "DomainFileStore", iteration => iteration.DomainFileStore },
            { "Element", iteration => iteration.Element },
            { "ExternalIdentifierMap", iteration => iteration.ExternalIdentifierMap },
            { "Goal", iteration => iteration.Goal },
            { "Option", iteration => iteration.Option.ToIdList() },
            { "PossibleFiniteStateList", iteration => iteration.PossibleFiniteStateList },
            { "Publication", iteration => iteration.Publication },
            { "Relationship", iteration => iteration.Relationship },
            { "RequirementsSpecification", iteration => iteration.RequirementsSpecification },
            { "RuleVerificationList", iteration => iteration.RuleVerificationList },
            { "SharedDiagramStyle", iteration => iteration.SharedDiagramStyle },
            { "Stakeholder", iteration => iteration.Stakeholder },
            { "StakeholderValue", iteration => iteration.StakeholderValue },
            { "StakeholderValueMap", iteration => iteration.StakeholderValueMap },
            { "ValueGroup", iteration => iteration.ValueGroup },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.Iteration, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Iteration, IEnumerable<OrderedItem>>>
        {
            { "Option", iteration => iteration.Option },
        };

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.Iteration"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.Iteration>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.Iteration>>
        {
            { "ActualFiniteStateList", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.ActualFiniteStateList != null, "The 'ActualFiniteStateList' property of a 'Iteration' is mandatory and cannot be null.") },
            { "DiagramCanvas", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.DiagramCanvas != null, "The 'DiagramCanvas' property of a 'Iteration' is mandatory and cannot be null.") },
            { "DomainFileStore", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.DomainFileStore != null, "The 'DomainFileStore' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Element", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Element != null, "The 'Element' property of a 'Iteration' is mandatory and cannot be null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'Iteration' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'Iteration' is mandatory and cannot be null.") },
            { "ExternalIdentifierMap", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.ExternalIdentifierMap != null, "The 'ExternalIdentifierMap' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Goal", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Goal != null, "The 'Goal' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Option", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Option != null && item.Option.Any(), "The 'Option' property of a 'Iteration' is mandatory and must have at least one entry.") },
            { "PossibleFiniteStateList", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.PossibleFiniteStateList != null, "The 'PossibleFiniteStateList' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Publication", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Publication != null, "The 'Publication' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Relationship", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Relationship != null, "The 'Relationship' property of a 'Iteration' is mandatory and cannot be null.") },
            { "RequirementsSpecification", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.RequirementsSpecification != null, "The 'RequirementsSpecification' property of a 'Iteration' is mandatory and cannot be null.") },
            { "RuleVerificationList", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.RuleVerificationList != null, "The 'RuleVerificationList' property of a 'Iteration' is mandatory and cannot be null.") },
            { "SharedDiagramStyle", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.SharedDiagramStyle != null, "The 'SharedDiagramStyle' property of a 'Iteration' is mandatory and cannot be null.") },
            { "Stakeholder", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.Stakeholder != null, "The 'Stakeholder' property of a 'Iteration' is mandatory and cannot be null.") },
            { "StakeholderValue", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.StakeholderValue != null, "The 'StakeholderValue' property of a 'Iteration' is mandatory and cannot be null.") },
            { "StakeholderValueMap", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.StakeholderValueMap != null, "The 'StakeholderValueMap' property of a 'Iteration' is mandatory and cannot be null.") },
            { "ValueGroup", new DtoValidationHelper<CDP4Common.DTO.Iteration>(item => item.ValueGroup != null, "The 'ValueGroup' property of a 'Iteration' is mandatory and cannot be null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing iteration)
        {
            this.Validate(iteration, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing iteration, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.Iteration)iteration);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing iteration)
        {
            return this.TryValidate(iteration, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing iteration, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.Iteration)iteration));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.Iteration"/>.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Iteration"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Iteration"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing iteration, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Iteration'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.Iteration)iteration);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.Iteration"/>.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="CDP4Common.DTO.Iteration"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Iteration"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing iteration, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Iteration'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.Iteration)iteration);
        }

        /// <summary>
        /// The CDP version property map.
        /// </summary>
        private readonly Dictionary<string, string> cdpVersionedProperties = new Dictionary<string, string>
        {
            { "DiagramCanvas", "1.1.0" },
            { "ExcludedDomain", "1.1.0" },
            { "ExcludedPerson", "1.1.0" },
            { "Goal", "1.1.0" },
            { "ModifiedOn", "1.1.0" },
            { "SharedDiagramStyle", "1.1.0" },
            { "Stakeholder", "1.1.0" },
            { "StakeholderValue", "1.1.0" },
            { "StakeholderValueMap", "1.1.0" },
            { "ValueGroup", "1.1.0" },
        };

        /// <summary>
        /// The containment property to type name map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> containmentTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ActualFiniteStateList", new PropertyMetaInfo("ActualFiniteStateList", "ActualFiniteStateList", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DiagramCanvas", new PropertyMetaInfo("DiagramCanvas", "DiagramCanvas", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DomainFileStore", new PropertyMetaInfo("DomainFileStore", "DomainFileStore", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Element", new PropertyMetaInfo("Element", "ElementDefinition", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "ExternalIdentifierMap", new PropertyMetaInfo("ExternalIdentifierMap", "ExternalIdentifierMap", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Goal", new PropertyMetaInfo("Goal", "Goal", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Option", new PropertyMetaInfo("Option", "Option", PropertyKind.OrderedList, AggregationKind.Composite, false, true, true, 1, "*", true) },
            { "PossibleFiniteStateList", new PropertyMetaInfo("PossibleFiniteStateList", "PossibleFiniteStateList", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Publication", new PropertyMetaInfo("Publication", "Publication", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Relationship", new PropertyMetaInfo("Relationship", "Relationship", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "RequirementsSpecification", new PropertyMetaInfo("RequirementsSpecification", "RequirementsSpecification", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "RuleVerificationList", new PropertyMetaInfo("RuleVerificationList", "RuleVerificationList", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "SharedDiagramStyle", new PropertyMetaInfo("SharedDiagramStyle", "SharedStyle", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Stakeholder", new PropertyMetaInfo("Stakeholder", "Stakeholder", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "StakeholderValue", new PropertyMetaInfo("StakeholderValue", "StakeholderValue", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "StakeholderValueMap", new PropertyMetaInfo("StakeholderValueMap", "StakeHolderValueMap", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "ValueGroup", new PropertyMetaInfo("ValueGroup", "ValueGroup", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="Iteration"/> class
        /// </summary>
        public IEnumerable<PropertyMetaInfo> Properties
        {
            get
            {
                foreach (var propertyMetaInfo in this.containmentTypeMap)
                {
                    yield return propertyMetaInfo.Value;
                }

                foreach (var propertyMetaInfo in this.propertyTypeMap)
                {
                    yield return propertyMetaInfo.Value;
                }
            }
        }

        /// <summary>
        /// The property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.Iteration, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Iteration, object>>
        {
            { "ActualFiniteStateList", thing => thing.ActualFiniteStateList },
            { "ClassKind", thing => thing.ClassKind },
            { "DefaultOption", thing => thing.DefaultOption },
            { "DiagramCanvas", thing => thing.DiagramCanvas },
            { "DomainFileStore", thing => thing.DomainFileStore },
            { "Element", thing => thing.Element },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "ExternalIdentifierMap", thing => thing.ExternalIdentifierMap },
            { "Goal", thing => thing.Goal },
            { "Iid", thing => thing.Iid },
            { "IterationSetup", thing => thing.IterationSetup },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Option", thing => thing.Option },
            { "PossibleFiniteStateList", thing => thing.PossibleFiniteStateList },
            { "Publication", thing => thing.Publication },
            { "Relationship", thing => thing.Relationship },
            { "RequirementsSpecification", thing => thing.RequirementsSpecification },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "RuleVerificationList", thing => thing.RuleVerificationList },
            { "SharedDiagramStyle", thing => thing.SharedDiagramStyle },
            { "SourceIterationIid", thing => thing.SourceIterationIid },
            { "Stakeholder", thing => thing.Stakeholder },
            { "StakeholderValue", thing => thing.StakeholderValue },
            { "StakeholderValueMap", thing => thing.StakeholderValueMap },
            { "TopElement", thing => thing.TopElement },
            { "ValueGroup", thing => thing.ValueGroup },
        };

        /// <summary>
        /// The property type map.
        /// </summary>
        /// <remarks>
        /// Contained properties are excluded for this map
        /// </remarks>
        private readonly Dictionary<string, PropertyMetaInfo> propertyTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "DefaultOption", new PropertyMetaInfo("DefaultOption", "Option", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "IterationSetup", new PropertyMetaInfo("IterationSetup", "IterationSetup", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "SourceIterationIid", new PropertyMetaInfo("SourceIterationIid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "TopElement", new PropertyMetaInfo("TopElement", "ElementDefinition", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "ActualFiniteStateList", (value) => (Guid)value },
            { "DiagramCanvas", (value) => (Guid)value },
            { "DomainFileStore", (value) => (Guid)value },
            { "Element", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "ExternalIdentifierMap", (value) => (Guid)value },
            { "Goal", (value) => (Guid)value },
            { "Option", (value) => (Guid)value },
            { "PossibleFiniteStateList", (value) => (Guid)value },
            { "Publication", (value) => (Guid)value },
            { "Relationship", (value) => (Guid)value },
            { "RequirementsSpecification", (value) => (Guid)value },
            { "RuleVerificationList", (value) => (Guid)value },
            { "SharedDiagramStyle", (value) => (Guid)value },
            { "Stakeholder", (value) => (Guid)value },
            { "StakeholderValue", (value) => (Guid)value },
            { "StakeholderValueMap", (value) => (Guid)value },
            { "ValueGroup", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.Iteration, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.Iteration, object>>
        {
            { "DefaultOption", (iteration, value) => iteration.DefaultOption = value == null ? (Guid?)null : (Guid)value },
            { "Iid", (iteration, value) => iteration.Iid = (Guid)value },
            { "IterationSetup", (iteration, value) => iteration.IterationSetup = (Guid)value },
            { "ModifiedOn", (iteration, value) => iteration.ModifiedOn = (DateTime)value },
            { "SourceIterationIid", (iteration, value) => iteration.SourceIterationIid = value == null ? (Guid?)null : (Guid)value },
            { "TopElement", (iteration, value) => iteration.TopElement = value == null ? (Guid?)null : (Guid)value },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "EngineeringModel", new PropertyMetaInfo("Iteration", "Iteration", PropertyKind.List, AggregationKind.Composite, false, false, true, 1, "*", true) },
        };

        /// <summary>
        /// Gets a value indicating whether this type should be deprecated upon Delete.
        /// </summary>
        public bool IsDeprecatableThing
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this type is a top container.
        /// </summary>
        public bool IsTopContainer
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the base type name of this class.
        /// </summary>
        public string BaseType
        {
            get { return "Thing"; }
        }

        /// <summary>
        /// Gets the CDP class version.
        /// </summary>
        public string ClassVersion
        {
            get { return null; }
        }

        /// <summary>
        /// Get the data model version of the supplied property.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// The version number as specified property otherwise the default data model version.
        /// </returns>
        public string GetPropertyVersion(string propertyName)
        {
            return this.cdpVersionedProperties.ContainsKey(propertyName) ? this.cdpVersionedProperties[propertyName] : null;
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.Iteration"/> containment property type from the supplied property name.
        /// </summary>
        /// <param name="propertyName">
        /// The containment property name.
        /// </param>
        /// <returns>
        /// The type name of the containment.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public PropertyMetaInfo GetContainmentType(string propertyName)
        {
            if (!this.containmentTypeMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Iteration'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.Iteration"/> property type from the supplied property name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="PropertyMetaInfo"/> or null if it does not exist.
        /// </returns>
        public PropertyMetaInfo GetPropertyMetaInfo(string propertyName)
        {
            if (this.containmentTypeMap.ContainsKey(propertyName))
            {
                return this.containmentTypeMap[propertyName];
            }

            if (this.propertyTypeMap.ContainsKey(propertyName))
            {
                return this.propertyTypeMap[propertyName];
            }

            return null;
        }

        /// <summary>
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.Iteration"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.Iteration"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.Iteration"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.Iteration"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.Iteration"/> is scalar.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// True if the supplied property name is a scalar property.
        /// </returns>
        public bool IsScalar(string propertyName)
        {
            if (this.propertyTypeMap.ContainsKey(propertyName))
            {
                var propertyInfo = this.propertyTypeMap[propertyName];
                return propertyInfo.PropertyKind == PropertyKind.Scalar || propertyInfo.PropertyKind == PropertyKind.ValueArray;
            }

            return false;
        }

        /// <summary>
        /// Apply the value update to the supplied property name of the updatable <see cref="CDP4Common.DTO.Thing"/> instance.
        /// </summary>
        /// <param name="updatableThing">
        /// The <see cref="CDP4Common.DTO.Thing"/> instance to which to apply the property value update.
        /// </param>
        /// <param name="propertyName">
        /// The property name of the <see cref="CDP4Common.DTO.Thing"/> to which to apply the value update.
        /// </param>
        /// <param name="value">
        /// The updated value to apply.
        /// </param>
        /// <returns>
        /// True if the value update was successfully applied.
        /// </returns>
        public bool ApplyPropertyUpdate(CDP4Common.DTO.Thing updatableThing, string propertyName, object value)
        {
            if (updatableThing == null || !this.IsScalar(propertyName))
            {
                return false;
            }

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.Iteration)updatableThing, value);

            return true;
        }

        /// <summary>
        /// Returns a deserialized object from the supplied value string for the property name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="value">
        /// The value to deserialize from its current string form.
        /// </param>
        /// <returns>
        /// A deserialized object from the supplied value.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public object DeserializeCollectionValue(string propertyName, object value)
        {
            if (!this.collectionPropertyValueDeserializationMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'Iteration'", propertyName));
            }

            return this.collectionPropertyValueDeserializationMap[propertyName](value);
        }

        /// <summary>
        /// Returns the value of the property of a Thing
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="thing">
        /// The Thing object
        /// </param>
        /// <returns>
        /// The value of the property of a Thing
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public object GetValue(string propertyName, CDP4Common.DTO.Thing thing)
        {
            if (!this.propertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'Iteration'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.Iteration)thing);
        }

        /// <summary>
        /// Gets the collection of property names for a <see cref="Thing"/>
        /// </summary>
        public IEnumerable<string> GetPropertyNameCollection()
        {
            var collection = new List<string>(this.propertyTypeMap.Keys);
            collection.AddRange(this.containmentTypeMap.Keys);
            return collection;
        }

        /// <summary>
        /// Instantiates a <see cref="CDP4Common.DTO.Iteration"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.Iteration(guid, revisionNumber);
        }
    }
}