using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using ToDoApp_API.Models;

namespace ToDoApp_App.Models;

public class User{

    [JsonPropertyName("id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("password")]
    public string Password{get; set;} = string.Empty;
    [JsonPropertyName("mail")]
    public string Mail { get; set; } = string.Empty;
    [JsonPropertyName("firstName")]
    public string FirtstName { get; set; } = string.Empty;
    [JsonPropertyName("lastName")]
    public string LastName{get;set;} = string.Empty;
    [JsonPropertyName("Note")]
    public ICollection<Note> Note{get; set;} = new List<Note>();

}