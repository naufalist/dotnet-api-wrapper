using System.Text.Json.Serialization;

namespace ApiWrapper.Models
{
    public class ApiContractUrl
    {
        public ApiContractUrl()
        {
            Base = string.Empty;
            Endpoint = string.Empty;
        }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }
    }
}
