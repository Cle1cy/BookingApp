using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class Message{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;} = 0;
    [JsonPropertyName("Content")]
    public string Content{ get; set;} = "";
    [JsonPropertyName("SendDate")]
    public DateTime SendDate { get; set;} = DateTime.MinValue;
}