using APIClient.APIClient.DTOModels;
using APIClient.APIClient.Interfaces;
using AXADevTest.APIClient;
using AXADevTest.APIClient.DTOModels;
using AXADevTest.Helpers;
using System;
using System.Threading.Tasks;

namespace APIClient.APIClient.Services
{
    public class ScheduleInterviewService : IScheduleInterviewService
    {
        public async Task<BaseResponse> ScheduleInterview(DTOModel_ScheduleInterviewDetails scheduleDetails)
        {
            string url = APIClientConfiguration.ApiServer + "schedule";

            return await new ClientWebRequests<BaseResponse>().PostAsync(url, scheduleDetails, null);
        }
    }
}
