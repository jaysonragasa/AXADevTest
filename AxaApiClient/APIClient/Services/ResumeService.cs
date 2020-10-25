using APIClient.APIClient.DTOModels;
using APIClient.APIClient.Interfaces;
using AXADevTest.APIClient;
using AXADevTest.APIClient.DTOModels;
using AXADevTest.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace APIClient.APIClient.Services
{
    public class ResumeService : IResumeService
    {
        public async Task<BaseResponse> UploadResume(string file)
        {
            BaseResponse response = new BaseResponse();

            FileInfo fileInfo = new FileInfo(file);
            if(fileInfo.Exists)
            {
                string base64filestring = null;

                using (FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[(int)stream.Length];

                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(bytes, 0, (int)stream.Length);

                    base64filestring = Convert.ToBase64String(bytes);
                }

                var dtofile = new DTOModel_File()
                {
                    File = new DTOModel_FileDetails()
                    {
                        Mime = "application/pdf",
                        Data = base64filestring
                    }
                };

                string url = APIClientConfiguration.ApiServer + "upload";
                response = await new ClientWebRequests<BaseResponse>().PostAsync(url, dtofile, "");
            }

            return response;
        }
    }
}
