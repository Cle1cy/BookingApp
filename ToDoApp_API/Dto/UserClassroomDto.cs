using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BookingApp_API.Models;

namespace BookingApp_API.Dto
{
    public class UserClassroomDto 
    {

        [JsonPropertyName("Users")]
        public User? User { get; set; } = null;
        [JsonPropertyName("StartDate")]
        public DateTime? StartDate { get; set; } = null;
        [JsonPropertyName("EndDate")]
        public DateTime? EndDate { get; set; } = null;
        [JsonPropertyName("Subject")]
        public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("Topic")]
        public string Topic { get; set; } = string.Empty;
    }
}
