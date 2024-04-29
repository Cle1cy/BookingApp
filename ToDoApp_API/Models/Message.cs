using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookingApp_API.Models;
public class Message{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set;} = 0;
    [JsonPropertyName("Content")]
    public string Content{ get; set;} = string.Empty;
    [JsonPropertyName("SendDate")]
    public DateTime SendDate { get; set;} = DateTime.MinValue;
}