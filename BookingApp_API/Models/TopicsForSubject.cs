using System.Text.Json.Serialization;

namespace BookingApp_API.Models
{
    public class TopicsForSubject
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Subject")]
        public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("Topic")]
        public string Topic { get; set; } = string.Empty;
    }
}
