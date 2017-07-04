using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Umbraco.GridData.Values
{
    /// <summary>
    /// Class representing the media value of a control.
    /// </summary>
    public class GridControlMediaValue : GridControlMediaValueBase
    {
        #region Properties

        /// <summary>
        /// Gets the caption of the media.
        /// </summary>
        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; protected set; }

        /// <summary>
        /// Gets whether the <see cref="Caption"/> property has a value.
        /// </summary>
        public bool HasCaption
        {
            get { return !String.IsNullOrWhiteSpace(Caption); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="control"/> and <paramref name="obj"/>.
        /// </summary>
        /// <param name="control">An instance of <see cref="GridControl"/> representing the control.</param>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the value of the control.</param>
        protected GridControlMediaValue(GridControl control, JObject obj)
            : base(control, obj)
        {
            Caption = obj.GetString("caption");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a media value from the specified <paramref name="control"/> and <paramref name="obj"/>.
        /// </summary>
        /// <param name="control">The parent control.</param>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        public static GridControlMediaValue Parse(GridControl control, JObject obj)
        {
            return obj == null ? null : new GridControlMediaValue(control, obj);
        }

        #endregion
    }
}