using System.Text.Json.Serialization;

namespace ApiWrapper.Models
{
    public class ApiContract
    {
        public ApiContract()
        {
            Url = new ApiContractUrl();
            Data = new ApiContractData();
        }

        [JsonPropertyName("url")]
        public ApiContractUrl Url { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("data")]
        public ApiContractData Data { get; set; }
    }
}
