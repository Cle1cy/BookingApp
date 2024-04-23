using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp_App.Models;
public class UserDetails {

    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("User")]
    public User? User { get; set; } = null;
    [JsonPropertyName("Card")]
    public int Card { get; set; } = 0;
    [JsonPropertyName("Csv")]
    public short Csv { get; set; } = 0;
    [JsonPropertyName("Date")]
    public string Date { get; set; } = "";
    [JsonPropertyName("Proprietary")]
    public string Proprietary { get; set; } = "";
    [JsonPropertyName("CardType")]
    public string CardType {get; set; } = "";
    [JsonPropertyName("PaymentInfo")]
    public string PaymentInfo { get; set; } = "";
}