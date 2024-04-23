
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class UserFriends{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;} = 0;
    [JsonPropertyName("User")]
    public User? User{ get; set;} = null;
    [JsonPropertyName("Friends")]
    public ICollection<User>? Friends { get; set;} = null;
}