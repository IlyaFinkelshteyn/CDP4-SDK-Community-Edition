﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AliasDeserializerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.IO;

namespace CDP4JsonSerializer.Tests.Deserializer
{
    using System;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;    
    using CDP4JsonSerializer.Tests.Helper;
    using NUnit.Framework;

    [TestFixture]
    public class AliasDeserializerTestFixture
    {
        private string aliasJson;
        private Cdp4JsonSerializer serializer;

        [SetUp]
        public void Setup()
        {
            var metamodel = new MetaDataProvider();
            this.serializer = new Cdp4JsonSerializer(metamodel, new Version(1, 1, 0));

            this.aliasJson = "[{ \"classKind\" : \"Alias\"," +
                             "  \"content\" : \"some conent\"," +                             
                             "  \"iid\" : \"d46aa66e-96c2-461e-91f3-1dfc4ce744b1\"," +
                             "  \"isSynonym\" : true," +
                             "  \"languageCode\" : \"en\"," +
                             "  \"modifiedOn\":\"2015-04-17T07:48:14.56Z\"," +
                             "  \"revisionNumber\" : 1" +
                             "}]";
        }

        [Test]
        public void VerifyThatAliasIsDeSerializedAsExpected()
        {
            using (var stream = StreamHelper.GenerateStreamFromString(this.aliasJson))
            {
                var result = this.serializer.Deserialize(stream);
                var alias = result.First() as Alias;

                var expectedModifiedOnDate = DateTime.Parse("2015-04-17T07:48:14.56Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);

                Assert.AreEqual(expectedModifiedOnDate, alias.ModifiedOn);
            }
        }

        [Test]
        public void VerifyThatAliasIsSerializedAsExpected()
        {
            var alias = new Alias()
            {
                Iid = Guid.Parse("d46aa66e-96c2-461e-91f3-1dfc4ce744b1"),
                Content = "some content",
                IsSynonym = true,
                LanguageCode = "en",
                ModifiedOn = DateTime.Parse("2015-04-17T07:48:14.56Z", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal),
                RevisionNumber = 1
            };

            using (var memoryStream = new MemoryStream())
            {
                this.serializer.SerializeToStream(new[] { alias }, memoryStream);
                memoryStream.Position = 0;

                using (var reader = new StreamReader(memoryStream))
                {
                    var txt = reader.ReadToEnd();

                    Console.WriteLine(txt);

                    Assert.IsTrue(txt.Contains("\"modifiedOn\":\"2015-04-17T07:48:14.560Z\""));
                }
            }            
        }
    }
}
