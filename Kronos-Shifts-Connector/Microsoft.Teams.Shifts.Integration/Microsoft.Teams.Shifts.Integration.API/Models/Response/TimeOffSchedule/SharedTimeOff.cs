// <copyright file="SharedTimeOff.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.API.Models.Response.TimeOffSchedule
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// This class models the SharedTimeOff.
    /// </summary>
    public partial class SharedTimeOff
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
        public DateTimeOffset StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the EndDateTime.
        /// </summary>
        [JsonProperty("endDateTime")]
        public DateTimeOffset EndDateTime { get; set; }
    }
}
