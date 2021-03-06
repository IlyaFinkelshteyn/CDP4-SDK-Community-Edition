// --------------------------------------------------------------------------------------------------------------------
// <copyright file "OwnedStyleSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The purpose of the <see cref="OwnedStyleSerializer"/> class is to provide a <see cref="OwnedStyle"/> specific serializer
    /// </summary>
    public class OwnedStyleSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "fillColor", fillColor => new JValue(fillColor) },
            { "fillOpacity", fillOpacity => new JValue(fillOpacity) },
            { "fontBold", fontBold => new JValue(fontBold) },
            { "fontColor", fontColor => new JValue(fontColor) },
            { "fontItalic", fontItalic => new JValue(fontItalic) },
            { "fontName", fontName => new JValue(fontName) },
            { "fontSize", fontSize => new JValue(fontSize) },
            { "fontStrokeThrough", fontStrokeThrough => new JValue(fontStrokeThrough) },
            { "fontUnderline", fontUnderline => new JValue(fontUnderline) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "strokeColor", strokeColor => new JValue(strokeColor) },
            { "strokeOpacity", strokeOpacity => new JValue(strokeOpacity) },
            { "strokeWidth", strokeWidth => new JValue(strokeWidth) },
            { "usedColor", usedColor => new JArray(usedColor) },
        };

        /// <summary>
        /// Serialize the <see cref="OwnedStyle"/>
        /// </summary>
        /// <param name="ownedStyle">The <see cref="OwnedStyle"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(OwnedStyle ownedStyle)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ownedStyle.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ownedStyle.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ownedStyle.ExcludedPerson));
            jsonObject.Add("fillColor", this.PropertySerializerMap["fillColor"](ownedStyle.FillColor));
            jsonObject.Add("fillOpacity", this.PropertySerializerMap["fillOpacity"](ownedStyle.FillOpacity));
            jsonObject.Add("fontBold", this.PropertySerializerMap["fontBold"](ownedStyle.FontBold));
            jsonObject.Add("fontColor", this.PropertySerializerMap["fontColor"](ownedStyle.FontColor));
            jsonObject.Add("fontItalic", this.PropertySerializerMap["fontItalic"](ownedStyle.FontItalic));
            jsonObject.Add("fontName", this.PropertySerializerMap["fontName"](ownedStyle.FontName));
            jsonObject.Add("fontSize", this.PropertySerializerMap["fontSize"](ownedStyle.FontSize));
            jsonObject.Add("fontStrokeThrough", this.PropertySerializerMap["fontStrokeThrough"](ownedStyle.FontStrokeThrough));
            jsonObject.Add("fontUnderline", this.PropertySerializerMap["fontUnderline"](ownedStyle.FontUnderline));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ownedStyle.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ownedStyle.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](ownedStyle.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ownedStyle.RevisionNumber));
            jsonObject.Add("strokeColor", this.PropertySerializerMap["strokeColor"](ownedStyle.StrokeColor));
            jsonObject.Add("strokeOpacity", this.PropertySerializerMap["strokeOpacity"](ownedStyle.StrokeOpacity));
            jsonObject.Add("strokeWidth", this.PropertySerializerMap["strokeWidth"](ownedStyle.StrokeWidth));
            jsonObject.Add("usedColor", this.PropertySerializerMap["usedColor"](ownedStyle.UsedColor));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="OwnedStyle"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var ownedStyle = thing as OwnedStyle;
            if (ownedStyle == null)
            {
                throw new InvalidOperationException("The thing is not a OwnedStyle.");
            }

            return this.Serialize(ownedStyle);
        }
    }
}
