using Newtonsoft.Json;

namespace VSMDivine.Api.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty(nameof(Success))]
        public bool Success { get; set; }
        [JsonProperty(nameof(Message))]
        public string? Message { get; set; }
        [JsonProperty(nameof(Result))]
        public T? Result { get; set; }
    }
}
