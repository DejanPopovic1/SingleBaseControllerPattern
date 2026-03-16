using System.Net;
using System.Text.Json.Serialization;

namespace BestPractice.Utilities;


public class ApiResponse<T>(HttpStatusCode status, string message, T? data = default)
{
    [JsonPropertyName("success")]
    public bool Success { get; set; } = true;

    [JsonPropertyName("status")]
    public HttpStatusCode Status { get; set; } = status;
    [JsonPropertyName("message")]
    public string Message { get; set; } = message;
    [JsonPropertyName("data")]
    public T? Data { get; set; } = data;
    [JsonPropertyName("error")]
    public object? Error { get; set; } = true;
}
