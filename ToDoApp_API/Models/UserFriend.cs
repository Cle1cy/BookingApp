
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class UserFriend{
    
    [JsonPropertyName("Id")]
    public User? Id { get; set;} = null;
    [JsonPropertyName("Friends")]
    public ICollection<User>? Friends { get; set;} = null;
}