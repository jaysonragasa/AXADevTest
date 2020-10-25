using AXADevTest.APIClient.DTOModels;
using System.Threading.Tasks;

namespace APIClient.APIClient.Interfaces
{
    public interface IResumeService
    {
        Task<BaseResponse> UploadResume(string file);
    }
}
