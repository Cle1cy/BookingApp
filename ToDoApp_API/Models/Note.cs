using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_API.Models;

public class Note{

    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("title")]
    public string title{ get; set;} = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set;} = string.Empty;
    [JsonPropertyName("state")]
    public int state { get; set; } = 0;
    [JsonPropertyName("startDate")]
    public string StartDate { get; set; } = string.Empty;
    [JsonPropertyName("dateOnly")]
    public string DateOnly { get; set;} = string.Empty;

    
}
