// <copyright file="DraftTimeOff.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.API.Models.Response.TimeOffSchedule
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the DraftTimeOff.
    /// </summary>
    public partial class DraftTimeOff
    {
        /// <summary>
        /// Gets or sets the TimeOffReasonId.
        /// </summary>
        [JsonProperty("timeOffReasonId")]
        public string TimeOffReasonId { get; set; }

        /// <summary>
        /// Gets or sets the StartDateTime.
        /// </summary>
        [JsonProperty("startDateTime")]
        public string StartDateTime{ get; set; }

        /// <summary>
        /// Gets or sets the EndDateTime.
        /// </summary>
        [JsonProperty("endDateTime")]
        public string EndDateTime { get; set; }
    }
}
