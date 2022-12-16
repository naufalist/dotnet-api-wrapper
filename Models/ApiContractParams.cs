using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiWrapper.Models
{
    public class ApiContractParams
    {
        public ApiContractParams()
        {
            Query = new Dictionary<string, string>();
            Route = new Dictionary<string, string>();
        }

        [JsonPropertyName("query")]
        public Dictionary<string, string> Query { get; set; }

        [JsonPropertyName("route")]
        public Dictionary<string, string> Route { get; set; }
    }
}
