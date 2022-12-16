using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiWrapper.Models
{
    public class ApiContractData
    {
        public ApiContractData()
        {
            Params = new ApiContractParams();
            Headers = new Dictionary<string, string>();
        }

        [JsonPropertyName("params")]
        public ApiContractParams Params { get; set; }

        [JsonPropertyName("headers")]
        public Dictionary<string, string> Headers { get; set; }

        [JsonPropertyName("body")]
        public object Body { get; set; }
    }
}
