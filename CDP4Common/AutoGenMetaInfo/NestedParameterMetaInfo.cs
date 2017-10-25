// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterMetaInfo.cs" company="RHEA System S.A.">
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
    /// This a class that holds meta info for <see cref="NestedParameter"/>.
    /// </summary>
    public partial class NestedParameterMetaInfo : INestedParameterMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.NestedParameter, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.NestedParameter, IEnumerable<Guid>>>();

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.NestedParameter, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.NestedParameter, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.NestedParameter>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.NestedParameter>>
        {
            { "ActualValue", new DtoValidationHelper<CDP4Common.DTO.NestedParameter>(item => !string.IsNullOrWhiteSpace(item.ActualValue), "The 'ActualValue' property of a 'NestedParameter' is mandatory and cannot be empty or null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.NestedParameter>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'NestedParameter' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.NestedParameter>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'NestedParameter' is mandatory and cannot be null.") },
            { "Formula", new DtoValidationHelper<CDP4Common.DTO.NestedParameter>(item => !string.IsNullOrWhiteSpace(item.Formula), "The 'Formula' property of a 'NestedParameter' is mandatory and cannot be empty or null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing nestedParameter)
        {
            this.Validate(nestedParameter, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing nestedParameter, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.NestedParameter)nestedParameter);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing nestedParameter)
        {
            return this.TryValidate(nestedParameter, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing nestedParameter, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.NestedParameter)nestedParameter));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.NestedParameter"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing nestedParameter, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'NestedParameter'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.NestedParameter)nestedParameter);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </summary>
        /// <param name="nestedParameter">
        /// The <see cref="CDP4Common.DTO.NestedParameter"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing nestedParameter, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'NestedParameter'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.NestedParameter)nestedParameter);
        }

        /// <summary>
        /// The CDP version property map.
        /// </summary>
        private readonly Dictionary<string, string> cdpVersionedProperties = new Dictionary<string, string>
        {
            { "ExcludedDomain", "1.1.0" },
            { "ExcludedPerson", "1.1.0" },
            { "ModifiedOn", "1.1.0" },
        };

        /// <summary>
        /// The containment property to type name map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> containmentTypeMap = new Dictionary<string, PropertyMetaInfo>();

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="NestedParameter"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.NestedParameter, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.NestedParameter, object>>
        {
            { "ActualState", thing => thing.ActualState },
            { "ActualValue", thing => thing.ActualValue },
            { "AssociatedParameter", thing => thing.AssociatedParameter },
            { "ClassKind", thing => thing.ClassKind },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "Formula", thing => thing.Formula },
            { "Iid", thing => thing.Iid },
            { "IsVolatile", thing => thing.IsVolatile },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Owner", thing => thing.Owner },
            { "RevisionNumber", thing => thing.RevisionNumber },
        };

        /// <summary>
        /// The property type map.
        /// </summary>
        /// <remarks>
        /// Contained properties are excluded for this map
        /// </remarks>
        private readonly Dictionary<string, PropertyMetaInfo> propertyTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ActualState", new PropertyMetaInfo("ActualState", "ActualFiniteState", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ActualValue", new PropertyMetaInfo("ActualValue", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "AssociatedParameter", new PropertyMetaInfo("AssociatedParameter", "ParameterBase", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Formula", new PropertyMetaInfo("Formula", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "IsVolatile", new PropertyMetaInfo("IsVolatile", "bool", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Owner", new PropertyMetaInfo("Owner", "DomainOfExpertise", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Path", new PropertyMetaInfo("Path", "string", PropertyKind.Scalar, AggregationKind.None, true, false, true, 1, "1", false) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.NestedParameter, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.NestedParameter, object>>
        {
            { "ActualState", (nestedParameter, value) => nestedParameter.ActualState = value == null ? (Guid?)null : (Guid)value },
            { "ActualValue", (nestedParameter, value) => nestedParameter.ActualValue = value.ToString() },
            { "AssociatedParameter", (nestedParameter, value) => nestedParameter.AssociatedParameter = (Guid)value },
            { "Formula", (nestedParameter, value) => nestedParameter.Formula = value.ToString() },
            { "Iid", (nestedParameter, value) => nestedParameter.Iid = (Guid)value },
            { "IsVolatile", (nestedParameter, value) => nestedParameter.IsVolatile = (bool)value },
            { "ModifiedOn", (nestedParameter, value) => nestedParameter.ModifiedOn = (DateTime)value },
            { "Owner", (nestedParameter, value) => nestedParameter.Owner = (Guid)value },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "NestedElement", new PropertyMetaInfo("NestedParameter", "NestedParameter", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
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
        /// Returns the <see cref="CDP4Common.DTO.NestedParameter"/> containment property type from the supplied property name.
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
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'NestedParameter'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.NestedParameter"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.NestedParameter"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.NestedParameter"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.NestedParameter"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.NestedParameter)updatableThing, value);

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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'NestedParameter'", propertyName));
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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'NestedParameter'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.NestedParameter)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.NestedParameter"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.NestedParameter(guid, revisionNumber);
        }
    }
}