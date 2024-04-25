using System.Text.Json.Serialization;
using ToDoApp_App.Models;

namespace ToDoApp_API.Models;

public class TutorDetails{
    [JsonPropertyName("Id")]
    public User? Id { get; set;} = null;
    [JsonPropertyName("Aptitudes")]
    public string Aptitudes { get; set;} = string.Empty;
    [JsonPropertyName("Cost")]
    public float Cost { get;set;} = 0.0f;
    [JsonPropertyName("Tutor")]
    public byte Tutor{ get;set;} = 0;
}