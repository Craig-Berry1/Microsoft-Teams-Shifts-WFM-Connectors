// <copyright file="TimeOffScheduleItem.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.API.Models.Response.TimeOffSchedule
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the TimeOffsItem.
    /// </summary>
    public partial class TimeOffScheduleItem
    {
        /// <summary>
        /// Gets or sets the OdataEtag.
        /// </summary>
        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDateTime.
        /// </summary>
        [JsonProperty("createdDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the LastModifiedDateTime.
        /// </summary>
        [JsonProperty("lastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the DraftTimeOff.
        /// </summary>
        [JsonProperty("draftTimeOff")]
        public DraftTimeOff DraftTimeOff { get; set; }

        /// <summary>
        /// Gets or sets the LastModifiedBy.
        /// </summary>
        [JsonProperty("lastModifiedBy")]
        public LastModifiedBy LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the SharedTimeOff.
        /// </summary>
        [JsonProperty("sharedTimeOff")]
        public SharedTimeOff SharedTimeOff { get; set; }
    }
}