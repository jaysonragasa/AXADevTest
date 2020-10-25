using AXADevTest.APIClient.DTOModels;
using AXADevTest.APIClient.Interfaces;
using AXADevTest.Helpers;
using System.Threading.Tasks;

namespace AXADevTest.APIClient.Services
{
    public class UserService : IUserService
    {
        string _token = string.Empty;

        public UserService()
        {

        }

        public async Task<BaseResponse> Register(DTOModel_UserDetails userDetails)
        {
            string url = APIClientConfiguration.ApiServer + "register";
            return await new ClientWebRequests<BaseResponse>().PostAsync(url, userDetails, _token);
        }
    }
}
