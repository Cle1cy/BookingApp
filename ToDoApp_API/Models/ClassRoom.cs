using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class ClassRoom{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;} = 0;
    [JsonPropertyName("Block")]
    public string Block{ get; set;} = string.Empty;
    [JsonPropertyName("Class")]
    public string Class { get; set; } = string.Empty;
    
 }