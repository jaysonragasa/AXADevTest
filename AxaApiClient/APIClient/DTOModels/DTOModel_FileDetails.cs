using Newtonsoft.Json;

namespace APIClient.APIClient.DTOModels
{
    public class DTOModel_File
    {
        [JsonProperty("file")]
        public DTOModel_FileDetails File { get; set; } = new DTOModel_FileDetails();
    }

    public class DTOModel_FileDetails
    {
        [JsonProperty("mime")]
        public string Mime { get; set; } = null;
        [JsonProperty("data")]
        public string Data { get; set; } = null;
    }
}
