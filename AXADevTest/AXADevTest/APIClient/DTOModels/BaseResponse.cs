using System.Net;

namespace AXADevTest.APIClient.DTOModels
{
    public class BaseResponse
    {
        //public bool Ok { get; set; } = false;
        public string Message { get; set; } = null;
        public HttpStatusCode Result { get; set; } = HttpStatusCode.NotFound;

        public object Payload { get; set; } = null;
    }
}
