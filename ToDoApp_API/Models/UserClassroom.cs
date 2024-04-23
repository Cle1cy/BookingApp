using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class UserClassroom{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;}
    [JsonPropertyName("Users")]
    public ICollection<User>? Users { get; set;} = null;
    [JsonPropertyName("ClassRooms")]
    public ICollection<ClassRoom>? ClassRooms { get; set;} = null;
    [JsonPropertyName("StartDate")]
    public DateTime StartDate { get; set; } = DateTime.MinValue;
    [JsonPropertyName("EndDate")]
    public DateTime EndDate { get; set; } = DateTime.MinValue;
    [JsonPropertyName("ConversationId")]
    public int ConversationId { get; set; } = 0;
    [JsonPropertyName("Messages")]
    public ICollection<Message>? Messages { get; set; } = null;
    [JsonPropertyName("Tutor")]
    public User? Tutor { get; set; } = null;


}
