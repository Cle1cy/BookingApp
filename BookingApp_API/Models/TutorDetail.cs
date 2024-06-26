using System.Text.Json.Serialization;
using BookingApp_API.Models;

namespace BookingApp_API.Models;

public class TutorDetail{
    [JsonPropertyName("Id")]
    public User? Id { get; set;} = null;
    [JsonPropertyName("Aptitudes")]
    public string Aptitudes { get; set;} = string.Empty;
    [JsonPropertyName("Cost")]
    public float Cost { get;set;} = 0.0f;
    [JsonPropertyName("Tutor")]
    public byte Tutor{ get;set;} = 0;
}