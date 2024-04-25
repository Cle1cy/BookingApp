using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class Notification{

    [JsonPropertyName("Id")]
    public User? Id { get; set;} = null;
    [JsonPropertyName("SendedUser")]
    public ICollection<User>? SendedUser { get; set;} = null;
    [JsonPropertyName("Message")]
    public string Message { get; set;} = string.Empty;
    [JsonPropertyName("IsDeclined")]
    public byte IsDeclined { get; set;} = 0;
}