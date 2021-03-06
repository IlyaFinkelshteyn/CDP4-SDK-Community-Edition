﻿// ------------------------------------------------------------------------------------------------
// <copyright file="PermissionService.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace CDP4Dal.Permission
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.MetaInfo;
    using CDP4Common.SiteDirectoryData;
    using NLog;

    /// <summary>
    /// The Permission Service class for the CDP4 application
    /// </summary>
    public class PermissionService : IPermissionService
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionService"/> class.
        /// </summary>
        /// <param name="session">The <see cref="ISession"/> that this <see cref="PermissionService"/> is handling.</param>
        public PermissionService(ISession session)
        {
            this.Session = session;
        }

        /// <summary>
        /// Gets the <see cref="ISession"/> that these permission service are responsible for.
        /// </summary>
        public ISession Session { get; private set; }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>True if a Read operation can be performed</returns>
        public bool CanRead(Thing thing)
        {
            // if the thing is null cancel out
            return thing != null && this.CanRead(thing, thing.GetType());
        }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="Thing"/>
        /// based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Read operation can be performed.</returns>
        private bool CanRead(Thing thing, Type thingType)
        {
            logger.Trace("CanRead invoked on Thing {0} of type {1}", thing, thingType);
            var topContainerClassKind = thing.TopContainer.ClassKind;

            switch (topContainerClassKind)
            {
                case ClassKind.SiteDirectory:
                    return this.CanReadSiteDirectoryContainedThing(thing, thingType);
                case ClassKind.EngineeringModel:
                    return this.CanReadEngineeringModelContainedThing(thing, thingType);
            }

            return false;
        }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="EngineeringModel"/> contained
        /// <see cref="Thing"/> based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Read operation can be performed.</returns>
        private bool CanReadEngineeringModelContainedThing(Thing thing, Type thingType)
        {
            var engineeringModel = thing.TopContainer;
            var participant =
                this.Session.ActivePersonParticipants.SingleOrDefault(
                    p => ((EngineeringModelSetup)p.Container).EngineeringModelIid == engineeringModel.Iid);

            if (participant == null || participant.Role == null)
            {
                return false;
            }

            var permission =
                participant.Role.ParticipantPermission.SingleOrDefault(perm => perm.ObjectClass == thing.ClassKind);

            if (thing.GetType() != thingType)
            {
                ClassKind superClassKind;

                if (Enum.TryParse(thingType.Name, out superClassKind))
                {
                    permission = participant.Role.ParticipantPermission.SingleOrDefault(perm => perm.ObjectClass == superClassKind);
                }
            }

            // if the permission is not found then get the default one.
            var accessRightKind = permission == null ? StaticDefaultPermissionProvider.GetDefaultParticipantPermission(thingType.Name) : permission.AccessRight;

            switch (accessRightKind)
            {
                case ParticipantAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanRead(thing.Container, thing.Container.GetType());
                case ParticipantAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanRead(thing, thing.GetType().BaseType);
                case ParticipantAccessRightKind.MODIFY:
                    return true;
                case ParticipantAccessRightKind.MODIFY_IF_OWNER:
                    var ownedThing = thing as IOwnedThing;

                    if (ownedThing != null)
                    {
                        return this.CanWriteIfParticipantOwned(ownedThing);
                    }

                    break;
                default:
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="SiteDirectory"/> contained
        /// <see cref="Thing"/> based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Read operation can be performed.</returns>
        private bool CanReadSiteDirectoryContainedThing(Thing thing, Type thingType)
        {
            var person = this.Session.ActivePerson;
            if (person == null)
            {
                return false;
            }

            var personRole = this.Session.ActivePerson.Role;
            if (personRole == null)
            {
                return false;
            }

            var permission = personRole.PersonPermission.SingleOrDefault(p => p.ObjectClass == thing.ClassKind);

            if (thing.GetType() != thingType)
            {
                ClassKind superClassKind;

                if (Enum.TryParse(thingType.Name, out superClassKind))
                {
                    permission = personRole.PersonPermission.SingleOrDefault(perm => perm.ObjectClass == superClassKind);
                }
            }

            // if the permission is not found or superclass derivation is used then get the default one.
            var accessRightKind = permission == null ? StaticDefaultPermissionProvider.GetDefaultPersonPermission(thingType.Name) : permission.AccessRight;

            switch (accessRightKind)
            {
                case PersonAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanRead(thing.Container, thing.Container.GetType());
                case PersonAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanRead(thing, thingType.BaseType);
                case PersonAccessRightKind.READ:
                case PersonAccessRightKind.MODIFY:
                    return true;
                case PersonAccessRightKind.MODIFY_IF_PARTICIPANT:
                case PersonAccessRightKind.READ_IF_PARTICIPANT:
                    if (thing is EngineeringModelSetup || thing.Container is EngineeringModelSetup)
                    {
                        var setup = thing as EngineeringModelSetup ?? thing.Container as EngineeringModelSetup;
                        return setup.Participant.Any(x => x.Person == this.Session.ActivePerson);
                    }

                    if (thing is SiteReferenceDataLibrary)
                    {
                        var rdl =
                            this.Session.RetrieveSiteDirectory()
                                .Model.SelectMany(ems => this.Session.GetEngineeringModelSetupRdlChain(ems));
                        return rdl.Contains(thing);
                    }

                    return false;
                case PersonAccessRightKind.MODIFY_OWN_PERSON:
                    return thing == person;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write</param>
        /// <returns>True if a Write operation can be performed</returns>
        public bool CanWrite(Thing thing)
        {
            logger.Trace("CanWrite invoked on Thing {0} ", thing);

            return thing != null && !this.Session.Dal.IsReadOnly && !thing.HasSentinelInstances && this.CanWrite(thing, thing.GetType());
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="Thing"/>
        /// based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Write operation can be performed.</returns>
        private bool CanWrite(Thing thing, Type thingType)
        {
            var topContainerClassKind = thing.TopContainer.ClassKind;

            switch (topContainerClassKind)
            {
                case ClassKind.SiteDirectory:
                    return this.CanWriteSiteDirectoryContainedThing(thing, thingType);
                case ClassKind.EngineeringModel:
                    return this.CanWriteEngineeringModelContainedThing(thing, thingType);
                default:
                    logger.Error("The top container of the {0} could not be resolved", thing.ClassKind);
                    return false;
            }
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="ClassKind"/>
        /// based on the supplied <see cref="Container"/>. The <see cref="ClassKind"/> ultimately determines the access. This method is primarily used for
        /// creation of a certain <see cref="Thing"/>.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerThing">The <see cref="Thing"/> to write to</param>
        /// <returns>True if Write operation can be performed.</returns>
        public bool CanWrite(ClassKind classKind, Thing containerThing)
        {
            logger.Trace("CanWrite invoked on ClassKind {0} and Container {1}", classKind, containerThing);

            if (this.Session.Dal.IsReadOnly)
            {
                return false;
            }

            var topContainerClassKind = containerThing.TopContainer.ClassKind;
            switch (topContainerClassKind)
            {
                case ClassKind.SiteDirectory:
                    return this.CanWriteSiteDirectoryContainedThing(classKind, containerThing, classKind);
                case ClassKind.EngineeringModel:
                    return this.CanWriteEngineeringModelContainedThing(classKind, containerThing, classKind);
            }

            return false;
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="EngineeringModel"/> contained
        /// <see cref="Thing"/> based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Write operation can be performed.</returns>
        private bool CanWriteEngineeringModelContainedThing(Thing thing, Type thingType)
        {
            var engineeringModel = thing.TopContainer;
            var iteration = thing.GetContainerOfType<Iteration>();
            if (iteration!= null && iteration.IterationSetup.FrozenOn != null)
            {
                return false;
            }

            var participant = this.Session.ActivePersonParticipants.SingleOrDefault(p => ((EngineeringModelSetup)p.Container).EngineeringModelIid == engineeringModel.Iid);

            if (participant == null || participant.Role == null)
            {
                return false;
            }

            var permission = participant.Role.ParticipantPermission.SingleOrDefault(perm => perm.ObjectClass == thing.ClassKind);

            if (thing.GetType() != thingType)
            {
                ClassKind superClassKind;

                if (Enum.TryParse(thingType.Name, out superClassKind))
                {
                    permission = participant.Role.ParticipantPermission.SingleOrDefault(perm => perm.ObjectClass == superClassKind);
                }
            }

            // if the permission is not found then get the default one.
            var accessRightKind = permission == null ? StaticDefaultPermissionProvider.GetDefaultParticipantPermission(thingType.Name) : permission.AccessRight;

            switch (accessRightKind)
            {
                case ParticipantAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanWrite(thing.Container, thing.Container.GetType());
                case ParticipantAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanWrite(thing, thing.GetType().BaseType);
                case ParticipantAccessRightKind.MODIFY:
                    return true;
                case ParticipantAccessRightKind.MODIFY_IF_OWNER:
                    var ownedThing = thing as IOwnedThing;

                    if (ownedThing != null)
                    {
                        return this.CanWriteIfParticipantOwned(ownedThing);
                    }

                    break;
                default:
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="ClassKind"/>
        /// based on the supplied <see cref="Container"/>. The <see cref="ClassKind"/> ultimately determines the access. This method is primarily used for
        /// creation of a certain <see cref="EngineeringModel"/> contained <see cref="Thing"/>.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerThing">The <see cref="Thing"/> to write to</param>
        /// <param name="thingType">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <returns>True if Write operation can be performed.</returns>
        private bool CanWriteEngineeringModelContainedThing(ClassKind classKind, Thing containerThing, ClassKind thingType)
        {
            var engineeringModel = containerThing.TopContainer as EngineeringModel;
            var iteration = containerThing.GetContainerOfType<Iteration>();
            if (iteration != null && iteration.IterationSetup.FrozenOn != null)
            {
                return false;
            }

            var participant = this.Session.ActivePersonParticipants.SingleOrDefault(p => ((EngineeringModelSetup)p.Container).EngineeringModelIid == engineeringModel.Iid);

            if (participant == null || participant.Role == null)
            {
                return false;
            }

            var permission = participant.Role.ParticipantPermission.SingleOrDefault(perm => perm.ObjectClass == classKind);

            // if the permission is not found then get the default one.
            var right = permission != null ? permission.AccessRight : StaticDefaultPermissionProvider.GetDefaultParticipantPermission(thingType.ToString());

            switch (right)
            {
                case ParticipantAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanWrite(containerThing, containerThing.GetType());
                case ParticipantAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanWriteBasedOnSuperclassClassKind(containerThing, thingType);
                case ParticipantAccessRightKind.MODIFY:
                case ParticipantAccessRightKind.MODIFY_IF_OWNER:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="SiteDirectory"/> contained
        /// <see cref="Thing"/> based on the supplied <see cref="Type"/>. The <see cref="Type"/> ultimately determines the access.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write, or the container if the permissions are based
        /// on the container.
        /// </param>
        /// <param name="thingType">The <see cref="Type"/> that ultimately determines the permissions.</param>
        /// <returns>True if Write operation can be performed.</returns>
        private bool CanWriteSiteDirectoryContainedThing(Thing thing, Type thingType)
        {
            var person = this.Session.ActivePerson;
            if (person == null)
            {
                return false;
            }

            var personRole = this.Session.ActivePerson.Role;
            if (personRole == null)
            {
                return false;
            }

            var permission = personRole.PersonPermission.SingleOrDefault(p => p.ObjectClass == thing.ClassKind);

            if (thing.GetType() != thingType)
            {
                ClassKind superClassKind;

                if (Enum.TryParse(thingType.Name, out superClassKind))
                {
                    permission = personRole.PersonPermission.SingleOrDefault(perm => perm.ObjectClass == superClassKind);
                }
            }

            // if the permission is not found or superclass derivation is used then get the default one.
            var accessRightKind = permission == null ? StaticDefaultPermissionProvider.GetDefaultPersonPermission(thingType.Name) : permission.AccessRight;

            switch (accessRightKind)
            {
                case PersonAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanWrite(thing.Container, thing.Container.GetType());
                case PersonAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanWrite(thing, thingType.BaseType);
                case PersonAccessRightKind.MODIFY:
                    return true;
                case PersonAccessRightKind.MODIFY_IF_PARTICIPANT:
                    if (thing is EngineeringModelSetup || thing.Container is EngineeringModelSetup)
                    {
                        var setup = thing as EngineeringModelSetup ?? thing.Container as EngineeringModelSetup;
                        return setup.Participant.Any(x => x.Person == this.Session.ActivePerson);
                    }

                    if (thing is SiteReferenceDataLibrary)
                    {
                        var rdl =
                            this.Session.RetrieveSiteDirectory()
                                .Model.SelectMany(ems => this.Session.GetEngineeringModelSetupRdlChain(ems));
                        return rdl.Contains(thing);
                    }

                    return false;
                case PersonAccessRightKind.MODIFY_OWN_PERSON:
                    return thing == person;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="ClassKind"/>
        /// based on the supplied <see cref="Container"/>. The <see cref="ClassKind"/> ultimately determines the access. This method is primarily used for
        /// creation of a certain <see cref="SiteDirectory"/> contained <see cref="Thing"/>.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerThing">The <see cref="Thing"/> to write to</param>
        /// <param name="thingType">The <see cref="ClassKind"/> that determine the permission</param>
        /// <returns>True if Write operation can be performed.</returns>
        private bool CanWriteSiteDirectoryContainedThing(ClassKind classKind, Thing containerThing, ClassKind thingType)
        {
            var person = this.Session.ActivePerson;
            if (person == null)
            {
                return false;
            }

            var personRole = this.Session.ActivePerson.Role;
            if (personRole == null)
            {
                return false;
            }

            var permission = personRole.PersonPermission.SingleOrDefault(p => p.ObjectClass == classKind);

            // if the permission is not found or superclass derivation is used then get the default one.
            var accessRightKind = permission == null ? StaticDefaultPermissionProvider.GetDefaultPersonPermission(thingType.ToString()) : permission.AccessRight;

            switch (accessRightKind)
            {
                case PersonAccessRightKind.SAME_AS_CONTAINER:
                    return this.CanWrite(containerThing, containerThing.GetType());
                case PersonAccessRightKind.SAME_AS_SUPERCLASS:
                    return this.CanWriteBasedOnSuperclassClassKind(containerThing, thingType);
                case PersonAccessRightKind.MODIFY:
                    return true;
                case PersonAccessRightKind.MODIFY_IF_PARTICIPANT:
                    if (containerThing is EngineeringModelSetup)
                    {
                        var setup = containerThing as EngineeringModelSetup;
                        return setup.Participant.Any(x => x.Person == this.Session.ActivePerson);
                    }

                    if (containerThing is SiteReferenceDataLibrary)
                    {
                        var rdl =
                                            this.Session.RetrieveSiteDirectory()
                                                .Model.SelectMany(ems => this.Session.GetEngineeringModelSetupRdlChain(ems));
                        return rdl.Contains(containerThing);
                    }

                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Resolves whether the write operation can be performed on a <see cref="Thing"/> of <see cref="Type"/>
        /// <see cref="thingType"/> based on the superclass of <see cref="thingType"/>
        /// </summary>
        /// <param name="containerThing">The container of the <see cref="Thing"/> that the write operation 
        /// needs to be performed on.</param>
        /// <param name="thingType">The <see cref="Type"/> of the <see cref="Thing"/> that will be write to.</param>
        /// <returns>True if the permissions of the superclass allow it.</returns>
        private bool CanWriteBasedOnSuperclassClassKind(Thing containerThing, ClassKind thingType)
        { 
            ClassKind superClassKind;
            var baseType = StaticMetadataProvider.BaseType(thingType.ToString());

            if (string.IsNullOrWhiteSpace(baseType))
            {
                return false;
            }

            return Enum.TryParse(baseType, out superClassKind) && this.CanWrite(superClassKind, containerThing);
        }

        /// <summary>
        /// Compute the write-permission for a <see cref="IOwnedThing"/> contained in an <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="ownedThing">The <see cref="IOwnedThing"/> contained by an <see cref="EngineeringModel"/></param>
        /// <returns>True if write permission is granted</returns>
        private bool CanWriteIfParticipantOwned(IOwnedThing ownedThing)
        {                        
            var thing = (Thing)ownedThing;

            var iteration = thing.GetContainerOfType<Iteration>();

            //Check if the iteration domain is null
            if (iteration != null && this.Session.OpenIterations.Single(x => x.Key == iteration).Value.Item1 == null)
            {
                return true;
            }

            //Check if the ownedThing domain is contained in the participant domains 
            if (iteration != null && this.Session.OpenIterations.Single(x => x.Key == iteration).Value.Item2 != null)
            {
                Participant participant = this.Session.OpenIterations.Single(x => x.Key == iteration).Value.Item2;
                if (participant.Domain.Contains(ownedThing.Owner))
                {
                    return true;
                }
            }

            // OwnedThing directly under EngineeringModel (CommonFileStore)
            // give permission if any active domain in the model
            
            // get all activedomain for the current model
            var currentModel = (EngineeringModel)thing.TopContainer;
            return this.Session.OpenIterations.Where(x => x.Key.Container == currentModel).Select(x => x.Value).Any();
        }
    }
}