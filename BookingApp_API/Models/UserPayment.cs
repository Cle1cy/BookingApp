using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookingApp_API.Models;
public class UserPayment {

    [JsonPropertyName("Id")]
    public User? Id { get; set; } = null;
    [JsonPropertyName("User")]
    public int Card { get; set; } = 0;
    [JsonPropertyName("Csv")]
    public short Csv { get; set; } = 0;
    [JsonPropertyName("Date")]
    public string Date { get; set; } = string.Empty;
    [JsonPropertyName("Proprietary")]
    public string Proprietary { get; set; } = string.Empty;
    [JsonPropertyName("CardType")]
    public string CardType {get; set; } = string.Empty;
    [JsonPropertyName("PaymentInfo")]
    public string PaymentInfo { get; set; } = string.Empty;
}