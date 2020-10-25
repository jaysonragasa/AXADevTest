using APIClient.APIClient.Interfaces;

namespace AXADevTest.APIClient.Interfaces
{
    public interface IServicesLocator
    {
        IUserService UserService { get; }
        IResumeService ResumeService { get; }
        IScheduleInterviewService ScheduleInterviewService { get; }

        void RegisterServices();
    }
}
