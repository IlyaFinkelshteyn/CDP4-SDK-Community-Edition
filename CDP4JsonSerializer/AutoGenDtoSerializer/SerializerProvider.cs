// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SerializerProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4JsonSerializer.Helper;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A static class that provides method to serialize a <see cref="Thing"/> or a <see cref="ClasslessDTO"/>
    /// </summary>
    public static class SerializerProvider
    {
        /// <summary>
        /// The map containing the Serializers
        /// </summary>
        private static readonly Dictionary<string, IThingSerializer> SerializerMap = new Dictionary<string, IThingSerializer>
        {
            { "ActionItem", new ActionItemSerializer() },
            { "ActualFiniteState", new ActualFiniteStateSerializer() },
            { "ActualFiniteStateList", new ActualFiniteStateListSerializer() },
            { "Alias", new AliasSerializer() },
            { "AndExpression", new AndExpressionSerializer() },
            { "Approval", new ApprovalSerializer() },
            { "ArrayParameterType", new ArrayParameterTypeSerializer() },
            { "BinaryNote", new BinaryNoteSerializer() },
            { "BinaryRelationship", new BinaryRelationshipSerializer() },
            { "BinaryRelationshipRule", new BinaryRelationshipRuleSerializer() },
            { "Book", new BookSerializer() },
            { "BooleanParameterType", new BooleanParameterTypeSerializer() },
            { "Bounds", new BoundsSerializer() },
            { "BuiltInRuleVerification", new BuiltInRuleVerificationSerializer() },
            { "Category", new CategorySerializer() },
            { "ChangeProposal", new ChangeProposalSerializer() },
            { "ChangeRequest", new ChangeRequestSerializer() },
            { "Citation", new CitationSerializer() },
            { "Color", new ColorSerializer() },
            { "CommonFileStore", new CommonFileStoreSerializer() },
            { "CompoundParameterType", new CompoundParameterTypeSerializer() },
            { "Constant", new ConstantSerializer() },
            { "ContractChangeNotice", new ContractChangeNoticeSerializer() },
            { "CyclicRatioScale", new CyclicRatioScaleSerializer() },
            { "DateParameterType", new DateParameterTypeSerializer() },
            { "DateTimeParameterType", new DateTimeParameterTypeSerializer() },
            { "DecompositionRule", new DecompositionRuleSerializer() },
            { "Definition", new DefinitionSerializer() },
            { "DerivedQuantityKind", new DerivedQuantityKindSerializer() },
            { "DerivedUnit", new DerivedUnitSerializer() },
            { "DiagramCanvas", new DiagramCanvasSerializer() },
            { "DiagramEdge", new DiagramEdgeSerializer() },
            { "DiagramObject", new DiagramObjectSerializer() },
            { "DomainFileStore", new DomainFileStoreSerializer() },
            { "DomainOfExpertise", new DomainOfExpertiseSerializer() },
            { "DomainOfExpertiseGroup", new DomainOfExpertiseGroupSerializer() },
            { "ElementDefinition", new ElementDefinitionSerializer() },
            { "ElementUsage", new ElementUsageSerializer() },
            { "EmailAddress", new EmailAddressSerializer() },
            { "EngineeringModel", new EngineeringModelSerializer() },
            { "EngineeringModelDataDiscussionItem", new EngineeringModelDataDiscussionItemSerializer() },
            { "EngineeringModelDataNote", new EngineeringModelDataNoteSerializer() },
            { "EngineeringModelSetup", new EngineeringModelSetupSerializer() },
            { "EnumerationParameterType", new EnumerationParameterTypeSerializer() },
            { "EnumerationValueDefinition", new EnumerationValueDefinitionSerializer() },
            { "ExclusiveOrExpression", new ExclusiveOrExpressionSerializer() },
            { "ExternalIdentifierMap", new ExternalIdentifierMapSerializer() },
            { "File", new FileSerializer() },
            { "FileRevision", new FileRevisionSerializer() },
            { "FileType", new FileTypeSerializer() },
            { "Folder", new FolderSerializer() },
            { "Glossary", new GlossarySerializer() },
            { "Goal", new GoalSerializer() },
            { "HyperLink", new HyperLinkSerializer() },
            { "IdCorrespondence", new IdCorrespondenceSerializer() },
            { "IntervalScale", new IntervalScaleSerializer() },
            { "Iteration", new IterationSerializer() },
            { "IterationSetup", new IterationSetupSerializer() },
            { "LinearConversionUnit", new LinearConversionUnitSerializer() },
            { "LogarithmicScale", new LogarithmicScaleSerializer() },
            { "MappingToReferenceScale", new MappingToReferenceScaleSerializer() },
            { "ModellingThingReference", new ModellingThingReferenceSerializer() },
            { "ModelLogEntry", new ModelLogEntrySerializer() },
            { "ModelReferenceDataLibrary", new ModelReferenceDataLibrarySerializer() },
            { "MultiRelationship", new MultiRelationshipSerializer() },
            { "MultiRelationshipRule", new MultiRelationshipRuleSerializer() },
            { "NaturalLanguage", new NaturalLanguageSerializer() },
            { "NestedElement", new NestedElementSerializer() },
            { "NestedParameter", new NestedParameterSerializer() },
            { "NotExpression", new NotExpressionSerializer() },
            { "Option", new OptionSerializer() },
            { "OrdinalScale", new OrdinalScaleSerializer() },
            { "OrExpression", new OrExpressionSerializer() },
            { "Organization", new OrganizationSerializer() },
            { "OwnedStyle", new OwnedStyleSerializer() },
            { "Page", new PageSerializer() },
            { "Parameter", new ParameterSerializer() },
            { "ParameterGroup", new ParameterGroupSerializer() },
            { "ParameterizedCategoryRule", new ParameterizedCategoryRuleSerializer() },
            { "ParameterOverride", new ParameterOverrideSerializer() },
            { "ParameterOverrideValueSet", new ParameterOverrideValueSetSerializer() },
            { "ParameterSubscription", new ParameterSubscriptionSerializer() },
            { "ParameterSubscriptionValueSet", new ParameterSubscriptionValueSetSerializer() },
            { "ParameterTypeComponent", new ParameterTypeComponentSerializer() },
            { "ParameterValueSet", new ParameterValueSetSerializer() },
            { "ParametricConstraint", new ParametricConstraintSerializer() },
            { "Participant", new ParticipantSerializer() },
            { "ParticipantPermission", new ParticipantPermissionSerializer() },
            { "ParticipantRole", new ParticipantRoleSerializer() },
            { "Person", new PersonSerializer() },
            { "PersonPermission", new PersonPermissionSerializer() },
            { "PersonRole", new PersonRoleSerializer() },
            { "Point", new PointSerializer() },
            { "PossibleFiniteState", new PossibleFiniteStateSerializer() },
            { "PossibleFiniteStateList", new PossibleFiniteStateListSerializer() },
            { "PrefixedUnit", new PrefixedUnitSerializer() },
            { "Publication", new PublicationSerializer() },
            { "QuantityKindFactor", new QuantityKindFactorSerializer() },
            { "RatioScale", new RatioScaleSerializer() },
            { "ReferencerRule", new ReferencerRuleSerializer() },
            { "ReferenceSource", new ReferenceSourceSerializer() },
            { "RelationalExpression", new RelationalExpressionSerializer() },
            { "RelationshipParameterValue", new RelationshipParameterValueSerializer() },
            { "RequestForDeviation", new RequestForDeviationSerializer() },
            { "RequestForWaiver", new RequestForWaiverSerializer() },
            { "Requirement", new RequirementSerializer() },
            { "RequirementsContainerParameterValue", new RequirementsContainerParameterValueSerializer() },
            { "RequirementsGroup", new RequirementsGroupSerializer() },
            { "RequirementsSpecification", new RequirementsSpecificationSerializer() },
            { "ReviewItemDiscrepancy", new ReviewItemDiscrepancySerializer() },
            { "RuleVerificationList", new RuleVerificationListSerializer() },
            { "RuleViolation", new RuleViolationSerializer() },
            { "ScaleReferenceQuantityValue", new ScaleReferenceQuantityValueSerializer() },
            { "ScaleValueDefinition", new ScaleValueDefinitionSerializer() },
            { "Section", new SectionSerializer() },
            { "SharedStyle", new SharedStyleSerializer() },
            { "SimpleParameterValue", new SimpleParameterValueSerializer() },
            { "SimpleQuantityKind", new SimpleQuantityKindSerializer() },
            { "SimpleUnit", new SimpleUnitSerializer() },
            { "SiteDirectory", new SiteDirectorySerializer() },
            { "SiteDirectoryDataAnnotation", new SiteDirectoryDataAnnotationSerializer() },
            { "SiteDirectoryDataDiscussionItem", new SiteDirectoryDataDiscussionItemSerializer() },
            { "SiteDirectoryThingReference", new SiteDirectoryThingReferenceSerializer() },
            { "SiteLogEntry", new SiteLogEntrySerializer() },
            { "SiteReferenceDataLibrary", new SiteReferenceDataLibrarySerializer() },
            { "Solution", new SolutionSerializer() },
            { "SpecializedQuantityKind", new SpecializedQuantityKindSerializer() },
            { "Stakeholder", new StakeholderSerializer() },
            { "StakeholderValue", new StakeholderValueSerializer() },
            { "StakeHolderValueMap", new StakeHolderValueMapSerializer() },
            { "StakeHolderValueMapSettings", new StakeHolderValueMapSettingsSerializer() },
            { "TelephoneNumber", new TelephoneNumberSerializer() },
            { "Term", new TermSerializer() },
            { "TextParameterType", new TextParameterTypeSerializer() },
            { "TextualNote", new TextualNoteSerializer() },
            { "TimeOfDayParameterType", new TimeOfDayParameterTypeSerializer() },
            { "UnitFactor", new UnitFactorSerializer() },
            { "UnitPrefix", new UnitPrefixSerializer() },
            { "UserPreference", new UserPreferenceSerializer() },
            { "UserRuleVerification", new UserRuleVerificationSerializer() },
            { "ValueGroup", new ValueGroupSerializer() },
        };

        /// <summary>
        /// Serialize a <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>The <see cref="JObject"/></returns>
        public static JObject ToJsonObject(this Thing thing)
        {
            IThingSerializer serializer;
            if(!SerializerMap.TryGetValue(thing.ClassKind.ToString(), out serializer))
            {
                throw new NotSupportedException(string.Format("The {0} class is not registered", thing.ClassKind));
            }

            return serializer.Serialize(thing);
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/>
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <returns>The <see cref="JObject"/></returns>
        public static JObject ToJsonObject(this ClasslessDTO classlessDto)
        {
            IThingSerializer serializer;
            if(!SerializerMap.TryGetValue(classlessDto["ClassKind"].ToString(), out serializer))
            {
                throw new NotSupportedException(string.Format("The {0} class is not registered", classlessDto["ClassKind"]));
            }

            var jsonObject = new JObject();
            foreach (var keyValue in classlessDto)
            {
                var key = Utils.LowercaseFirstLetter(keyValue.Key);
                jsonObject.Add(key, serializer.PropertySerializerMap[key](keyValue.Value)); 
            }

            return jsonObject;
        }
    }
}
