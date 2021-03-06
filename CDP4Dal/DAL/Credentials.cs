﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Credentials.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="Credentials"/> class is to store the username, password and <see cref="Uri"/>
    /// of a data-store that an implementation of <see cref="Dal"/> will connect to.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Backing field of the <see cref="Password"/> property where the password is stored
        /// </summary>
        private readonly string password;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class. 
        /// </summary>
        /// <param name="username">
        /// The username that is used to connect to a data-store
        /// </param>
        /// <param name="password">
        /// the password that is sued to connect to a data-store
        /// </param>
        /// <param name="uri">
        /// the <see cref="Uri"/> of the data-store
        /// </param>
        /// <param name="archivepassword">The password of the archive, to be set if the </param>
        public Credentials(string username, string password, Uri uri)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username", "The username may not be empty or null");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "The password may not be empty or null");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri", "The uri may not be null");
            }

            this.UserName = username;
            this.password = password;
            this.Uri = uri;
        }

        /// <summary>
        /// Gets the username that is used to connect to a data-store
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password that is used to connect to a data-store
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the data-store 
        /// </summary>
        public Uri Uri { get; private set; }
    }
}