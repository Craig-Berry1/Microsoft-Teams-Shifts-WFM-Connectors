// <copyright file="IOpenShiftRequestController.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Shifts.Integration.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Teams.Shifts.Integration.API.Models.IntegrationAPI;
    using Microsoft.Teams.Shifts.Integration.API.Models.IntegrationAPI.Incoming;
    using Microsoft.Teams.Shifts.Integration.BusinessLogic.Models;
    using Microsoft.Teams.Shifts.Integration.BusinessLogic.ResponseModels;

    public interface IOpenShiftRequestController
    {
        /// <summary>
        /// Method to submit the Open Shift Request in Kronos.
        /// </summary>
        /// <param name="request">The request object that is coming in.</param>
        /// <param name="teamId">The Shifts team id.</param>
        /// <returns>Making sure to return a successful response code.</returns>
        Task<List<ShiftsIntegResponse>> ProcessCreateOpenShiftRequestFromTeamsAsync(OpenShiftRequestIS request, string teamId);

        /// <summary>
        /// Processes an open shift request that has been created via the logic app sync.
        /// </summary>
        /// <param name="jsonModel">The decrypted JSON payload.</param>
        /// <param name="teamId">The id of the team where the request came from.</param>
        /// <param name="updateProps">A dictionary of string, string that will be logged to ApplicationInsights.</param>
        /// <param name="kronosTimeZone">The time zone to use when converting the times.</param>
        /// <returns>A unit of execution.</returns>
        Task<List<ShiftsIntegResponse>> ProcessOpenShiftRequestApprovalAsync(RequestModel jsonModel, string teamId, Dictionary<string, string> updateProps, string kronosTimeZone);

        /// <summary>
        /// This method processes an approval that happens in the Shifts app.
        /// </summary>
        /// <param name="jsonModel">The decrypted JSON payload.</param>
        /// <param name="teamId">The team id the request belongs to.</param>
        /// <param name="updateProps">A dictionary of string, string that will be logged to ApplicationInsights.</param>
        /// <param name="kronosTimeZone">The time zone to use when converting the times.</param>
        /// <param name="approved">Whether the </param>
        /// <returns>A unit of execution.</returns>
        Task<List<ShiftsIntegResponse>> ProcessOpenShiftRequestApprovalFromTeamsAsync(RequestModel jsonModel, string teamId, Dictionary<string, string> updateProps, string kronosTimeZone, bool approved);

        /// <summary>
        /// This method will process the Open Shift requests from Kronos to Teams.
        /// </summary>
        /// <param name="isRequestFromLogicApp">The value indicating whether or not the request is coming from logic app.</param>
        /// <returns>A unit of execution.</returns>
        Task ProcessOpenShiftRequestsAsync(string isRequestFromLogicApp);

        /// <summary>
        /// This method is to retract an open shift request made by the FLW.
        /// </summary>
        /// <param name="map">The open shift mapping entity.</param>
        /// <returns>A unit of execution.</returns>
        Task<ShiftsIntegResponse> RetractRequestedShiftAsync(AllOpenShiftRequestMappingEntity map);
    }
}