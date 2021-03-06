﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dal.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;
    using CDP4Common.MetaInfo;
    using CDP4Dal.Operations;
    using CDP4Dal.Composition;
    using CDP4Dal.Exceptions;
    using Iteration = CDP4Common.DTO.Iteration;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// An abstract Data Access Layer class.
    /// </summary>
    public abstract class Dal : IDal
    {
        //TODO: the EngineeringModelKinds property should be generated from the model, the risk by coding it here is that 
        // we forget to update this when we update the uml data-model. -> T1459
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Dal"/> class
        /// </summary>
        protected Dal()
        {
            this.MetaDataProvider = StaticMetadataProvider.GetMetaDataProvider;
            this.SetCdpVersion();
        }
        
        /// <summary>
        /// Gets the supported version of the data-model
        /// </summary>
        public Version DalVersion { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="ISession"/> that uses this <see cref="IDal"/>
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Credentials"/> that are used to connect the data-store
        /// </summary>
        public Credentials Credentials { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="IMetaDataProvider"/>
        /// </summary>
        public IMetaDataProvider MetaDataProvider { get; protected set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        public abstract bool IsReadOnly { get; }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null);
        
        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null);

        /// <summary>
        /// Reads the data related to the provided <see cref="Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="token">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be passed along with the request
        /// </param>
        /// <returns>
        /// a list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/> itself
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null) where T : Thing;

        /// <summary>
        /// Reads the data related to the provided <see cref="CDP4Common.DTO.Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="CDP4Common.DTO.Iteration"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="CDP4Common.DTO.EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null);

        /// <summary>
        /// Creates the specified <see cref="Thing"/> on a data source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed. This includes the thing that was created.
        /// </returns>
        public abstract IEnumerable<Thing> Create<T>(T thing) where T : Thing;

        /// <summary>
        /// Performs an update to the <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be updated
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public abstract IEnumerable<Thing> Update<T>(T thing) where T : Thing;

        /// <summary>
        /// Deletes the specified <see cref="Thing"/> from the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be deleted
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public abstract IEnumerable<Thing> Delete<T>(T thing) where T : Thing;

        /// <summary>
        /// Opens a connection to a data source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> that the services return when connecting to the <see cref="CDP4Common.DTO.SiteDirectory"/>.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Closes the connection to the data-source.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>
        /// </param>
        /// <returns>
        /// true when valid, false when invalid
        /// </returns>
        public abstract bool IsValidUri(string uri);

        /// <summary>
        /// Closes the active session
        /// </summary>
        public virtual void CloseSession()
        {
            this.Credentials = null;
        }

        /// <summary>
        /// If the given Uri ends with '/' remove it.
        /// </summary>
        /// <param name="uri">
        /// The uri to clean up.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> consisting of either the uri.
        /// </returns>
        protected string CleanUriFinalSlash(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return string.Empty;
            }

            return uri.EndsWith("/") ? uri.TrimEnd(uri[uri.Length - 1]) : uri;
        }

        /// <summary>
        /// Set the <see cref="Iteration"/> container id for all applicable <see cref="Thing"/>
        /// </summary>
        /// <param name="dtos">
        /// The <see cref="Thing"/> to set
        /// </param>
        /// <param name="iterationId">
        /// The iteration Id.
        /// </param>
        public virtual void SetIterationContainer(IEnumerable<Thing> dtos, Guid iterationId)
        {
            if (iterationId == Guid.Empty)
            {
                throw new ArgumentException("The Iteration Id must be set");
            }

            var engineeringModelContainmentClassKind = EngineeringModelContainmentClassType.ClassKindArray;

            foreach (var thing in dtos.Where(x => !engineeringModelContainmentClassKind.Contains(x.ClassKind)))
            {
                // all the returned thing are iteration contained
                thing.IterationContainerId = iterationId;
            }
        }

        /// <summary>
        /// Extract the iteration containment id from the supplied uri.
        /// </summary>
        /// <param name="uri">
        /// The uri route of the iteration contained resource.
        /// </param>
        /// <param name="iterationId">
        /// The iteration Id.
        /// </param>
        /// <returns>
        /// true if iteration id was extracted from the uri, otherwise false
        /// </returns>
        /// <exception cref="ApplicationException">
        /// If uri is not a valid iteration containment route
        /// </exception>
        public bool TryExtractIterationIdfromUri(Uri uri, out Guid iterationId)
        {
            try
            {
                var uriString = uri.ToString();
                var iterationUriName = ContainerPropertyHelper.ContainerPropertyName(ClassKind.Iteration);
                var regexPatter = iterationUriName + Constants.UriPathSeparator + Constants.UriGuidPattern;

                var match = Regex.Match(uriString, regexPatter);
                if (!match.Success)
                {
                    iterationId = Guid.Empty;
                    return false;
                }

                var id = match.Value.Split(Constants.UriPathSeparatorChar).Last();
                iterationId = new Guid(id);
                return true;
            }
            catch (Exception)
            {
                iterationId = Guid.Empty;
                return false;
            }
        }

        /// <summary>
        /// Queries the request context from the uri which is either the route to an specific <see cref="CDP4Common.DTO.SiteDirectory"/> or a specific <see cref="Iteration"/>
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> to a 10-25 resource
        /// </param>
        /// <returns>
        /// A string that represents the route to a specific <see cref="CDP4Common.DTO.SiteDirectory"/> or <see cref="Iteration"/> using the following
        /// format: /SiteDirectory/{iid} /EngineeringModel/{iid}/iteration/{iid}
        /// </returns>
        public string QueryRequestContext(Uri uri)
        {
            var siteDirectoryPattern = @"(/SiteDirectory" + Constants.UriPathSeparator + Constants.UriGuidPattern + ")";
            var match = Regex.Match(uri.AbsolutePath, siteDirectoryPattern);
            if (match.Success)
            {
                return match.Groups[0].Value;
            }

            var iterationPattern = @"(/EngineeringModel" + Constants.UriPathSeparator + Constants.UriGuidPattern + Constants.UriPathSeparator + "iteration" + Constants.UriPathSeparator + Constants.UriGuidPattern + ")";
            match = Regex.Match(uri.AbsolutePath, iterationPattern);
            if (match.Success)
            {
                return match.Groups[0].Value;
            }

            return uri.AbsolutePath;
        }

        /// <summary>
        /// Verifies that the hash of the provided files machtches the hashes of the <see cref="CDP4Common.DTO.FileRevision"/>
        /// objects in the <see cref="OperationContainer"/>.
        /// </summary>
        /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/> that contains the <see cref="Operation"/>s that need to be verified
        /// </param>
        /// <param name="files">
        /// The paths to the files whose sha1 hash needs to match the hash present in the <see cref="OperationContainer"/>
        /// </param>
        /// <exception cref="InvalidOperationContainerException">
        /// An <see cref="InvalidOperationContainerException"/> is thrown when the <see cref="OperationContainer"/> does not contain an <see cref="Operation"/>
        /// that contains a <see cref="CDP4Common.DTO.FileRevision"/> instant whose contenthash matches the hash of the provided <paramref name="files"/>.
        /// </exception>        
        protected void OperationContainerFileVerification(OperationContainer operationContainer, IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                string utf8EconcodedHAsh = string.Empty;
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    using (var cryptoProvider = new SHA1CryptoServiceProvider())
                    {
                        utf8EconcodedHAsh = BitConverter.ToString(cryptoProvider.ComputeHash(fileStream)).Replace("-", "").ToLower();
                    }
                }

                var contentFoundInAnOperation = false;
                foreach (var operation in operationContainer.Operations)
                {
                    var fileRevision = operation.ModifiedThing as CDP4Common.DTO.FileRevision;
                    if (fileRevision != null && fileRevision.ContentHash == utf8EconcodedHAsh)
                    {
                        contentFoundInAnOperation = true;
                        break;
                    }
                }

                if (!contentFoundInAnOperation)
                {
                    throw new InvalidOperationContainerException(string.Format("The hash of the specified file {0} could not be found in the operation", file));
                }
            }
        }

        /// <summary>
        /// Generate a stream from a string
        /// </summary>
        /// <param name="s">The string input</param>
        /// <returns>The stream</returns>
        protected Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Generate a string for the <see cref="MemoryStream"/>
        /// </summary>
        /// <param name="memoryStream">The source <see cref="MemoryStream"/></param>
        /// <returns>The string content</returns>
        protected string MemoryStreamToString(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            var sr = new StreamReader(memoryStream);
            var result = sr.ReadToEnd();
            memoryStream.Position = 0;
            return result;
        }

        /// <summary>
        /// Sets the CDP Version data model version that is supported by the current <see cref="CDP4Dal.Session"/>
        /// </summary>
        /// <param name="dal">
        /// The <see cref="IDal"/> the current <see cref="CDP4Dal.Session"/>
        /// </param>
        /// <remarks>
        /// In case the <paramref name="dal"/> is not decorated with <see cref="DalExportAttribute"/> then
        /// the <see cref="Version"/> is set to "1.0.0.0"
        /// </remarks>
        protected virtual void SetCdpVersion()
        {
            var dalType = this.GetType();
            var dalExportAttribute = (DalExportAttribute)Attribute.GetCustomAttribute(dalType, typeof(DalExportAttribute));
            if (dalExportAttribute != null)
            {
                this.DalVersion = new Version(dalExportAttribute.CDPVersion);
            }
            else
            {
                this.DalVersion = new Version("1.0.0");
            }
        }
    }
}