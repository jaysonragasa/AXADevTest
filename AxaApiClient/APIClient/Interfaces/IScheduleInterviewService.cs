using APIClient.APIClient.DTOModels;
using AXADevTest.APIClient.DTOModels;
using System.Threading.Tasks;

namespace APIClient.APIClient.Interfaces
{
    public interface IScheduleInterviewService
    {
        Task<BaseResponse> ScheduleInterview(DTOModel_ScheduleInterviewDetails scheduleDetails);
    }
}
