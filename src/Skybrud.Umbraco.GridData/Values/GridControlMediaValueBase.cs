﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Umbraco.GridData.Values
{
    /// <summary>
    /// Class representing the media value of a control.
    /// </summary>
    public abstract class GridControlMediaValueBase : GridControlValueBase
    {
        #region Properties

        /// <summary>
        /// Gets the focal point with information on how the iamge should be cropped.
        /// </summary>
        [JsonProperty("focalPoint")]
        public GridControlMediaFocalPoint FocalPoint { get; protected set; }

        /// <summary>
        /// Gets the ID of the image.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; protected set; }

        /// <summary>
        /// Gets the URL of the media.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; protected set; }

        /// <summary>
        /// Gets the alt text of the media.
        /// </summary>
        [JsonProperty("altText", NullValueHandling = NullValueHandling.Ignore)]
        public string AltText { get; protected set; }

        /// <summary>
        /// Gets whether the <see cref="AltText"/> property has a value.
        /// </summary>
        public bool HasAltText
        {
            get { return !String.IsNullOrWhiteSpace(AltText); }
        }

        /// <summary>
        /// Gets whether the value is valid. For an instance of <see cref="GridControlMediaValueBase"/>, this means
        /// checking whether an image has been selected. The property will however not validate the image against the
        /// media cache.
        /// </summary>
        [JsonIgnore]
        public override bool IsValid
        {
            get { return Id > 0; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="control"/> and <paramref name="obj"/>.
        /// </summary>
        /// <param name="control">An instance of <see cref="GridControl"/> representing the control.</param>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the value of the control.</param>
        protected GridControlMediaValueBase(GridControl control, JObject obj) : base(control, obj)
        {
            FocalPoint = obj.GetObject("focalPoint", GridControlMediaFocalPoint.Parse);
            Id = obj.GetInt32("id");
            Image = obj.GetString("image");
            AltText = obj.GetString("altText");
        }

        #endregion
    }
}