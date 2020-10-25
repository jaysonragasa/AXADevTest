using AXADevTest.APIClient.Services;

namespace AXADevTest.APIClient.Interfaces
{
    public interface IServicesLocator
    {
        IUserService UserService { get; }

        void RegisterServices();
    }
}
