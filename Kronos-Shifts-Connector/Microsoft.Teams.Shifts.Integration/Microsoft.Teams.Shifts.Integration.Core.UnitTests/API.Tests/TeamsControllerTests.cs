using Microsoft.Teams.App.KronosWfc.Common;
using Microsoft.Teams.Shifts.Integration.API.Common;
using Microsoft.Teams.Shifts.Integration.API.Controllers;
using Microsoft.Teams.Shifts.Integration.BusinessLogic.Models;
using Microsoft.Teams.Shifts.Integration.BusinessLogic.Providers;
using Microsoft.Teams.Shifts.Integration.BusinessLogic.ResponseModels;
using Microsoft.Teams.Shifts.Integration.Core.UnitTests.Common;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Teams.Shifts.Integration.Core.UnitTests.API.Tests
{
    public class TeamsControllerTests
    {
        /// <summary>
        /// This unit test mimics the behaviour of cancelling an open shift request. The ProcessOpenShiftRequest method is private
        /// meaning we had to by hand map out the logic of this condition which is not ideal. However, one level higher in the stack 
        /// was also not ideal as that is the public sync method and would involve more mocking than would be worth for this test case.
        /// </summary>
        /// <param name="id">ID of entity to retract</param>
        /// <param name="allOpenShiftRequestMappingEntity">The open shift request.</param>
        /// <param name="openShiftRequestMappingEntityProvider">The provider with logic for open shift requests.</param>
        /// <param name="openShiftController">Open shift controller business logic.</param>
        [Theory]
        [InlineAutoNSubstituteData()]
        public void ProcessOpenShiftRequest_ValidInput_Returns200(
            string id,
            AllOpenShiftRequestMappingEntity allOpenShiftRequestMappingEntity,
            IOpenShiftRequestMappingEntityProvider openShiftRequestMappingEntityProvider,
            IOpenShiftRequestController openShiftController
        )
        {
            //  Arrange
            List<ShiftsIntegResponse> responseModelList = new List<ShiftsIntegResponse>();

            //  Act
            openShiftRequestMappingEntityProvider.GetOpenShiftRequestMappingEntityByRowKeyAsync(id).Returns(Task.FromResult(allOpenShiftRequestMappingEntity));

            var entityToCancel = openShiftRequestMappingEntityProvider.GetOpenShiftRequestMappingEntityByRowKeyAsync(id).Result;

            if (entityToCancel != null)
            {
                if (entityToCancel.KronosStatus != ApiConstants.Retract)
                {
                    responseModelList.Add(openShiftController.RetractRequestedShiftAsync(entityToCancel).Result);

                    entityToCancel.ShiftsStatus = ApiConstants.SwapShiftCancelled;

                    openShiftRequestMappingEntityProvider.SaveOrUpdateOpenShiftRequestMappingEntityAsync(entityToCancel).Returns(Task.FromResult(allOpenShiftRequestMappingEntity));
                }
            }

            var integrationResponse = new ShiftsIntegResponse();
            integrationResponse = ResponseHelper.CreateSuccessfulResponse(id);
            responseModelList.Add(integrationResponse);

            //  Assert
            Assert.NotNull(responseModelList);
            Assert.True(integrationResponse.Status.Equals(200));
            Assert.Equal(id, integrationResponse.Id);
            Assert.Equal(ApiConstants.SwapShiftCancelled, entityToCancel.ShiftsStatus);

        }
    }
}
