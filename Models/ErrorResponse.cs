using System.Text.Json.Serialization;

namespace ApiWrapper.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; } = -1;

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
