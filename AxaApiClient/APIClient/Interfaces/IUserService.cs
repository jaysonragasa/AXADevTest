using AXADevTest.APIClient.DTOModels;
using System.Threading.Tasks;

namespace AXADevTest.APIClient.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse> Register(DTOModel_UserDetails userDetails);
    }
}
