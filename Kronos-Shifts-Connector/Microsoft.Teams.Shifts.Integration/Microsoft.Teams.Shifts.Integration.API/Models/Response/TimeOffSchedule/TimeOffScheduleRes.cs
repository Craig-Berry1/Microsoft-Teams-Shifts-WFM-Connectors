// <copyright file="TimeOffScheduleRes.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.API.Models.Response.TimeOffSchedule
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// This class models the Time Off Shift.
    /// </summary>
    public class TimeOffScheduleRes
    {
        /// <summary>
        /// Gets or sets the Context in Shifts for getting more timeoff requests.
        /// </summary>
        [JsonProperty("@odata.context")]
        public Uri NextLink { get; set; }

        /// <summary>
        /// Gets or sets the Time Off Schedule item.
        /// </summary>
        [JsonProperty("value")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<TimeOffScheduleItem> TOSItem { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}