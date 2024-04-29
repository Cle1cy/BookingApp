using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookingApp_API.Models;
public class UserClassroom{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;}
    [JsonPropertyName("ClassRooms")]
    public ICollection<ClassRoom>? ClassRooms { get; set;} = null;
    [JsonPropertyName("Users")]
    public ICollection<User>? Users { get; set;} = null;
    [JsonPropertyName("StartDate")]
    public DateTime? StartDate { get; set; } = null;
    [JsonPropertyName("EndDate")]
    public DateTime? EndDate { get; set; } = null;
    [JsonPropertyName("ConversationId")]
    public int ConversationId { get; set; } = 0;
    [JsonPropertyName("Messages")]
    public ICollection<Message>? Messages { get; set; } = null;
    [JsonPropertyName("Tutor")]
    public User? Tutor { get; set; } = null;
    [JsonPropertyName("Subject")]
    public string Subject {get; set;} = string.Empty;
    [JsonPropertyName("Topic")]
    public string Topic { get; set;} = string.Empty;


}
