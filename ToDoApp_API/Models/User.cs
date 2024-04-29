using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace BookingApp_API.Models;

public class User{

    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; } = 0;
    [JsonPropertyName("Password")]
    public string Password{get; set;} = string.Empty;
    [JsonPropertyName("Mail")]
    public string Mail { get; set; } = string.Empty;
    [JsonPropertyName("FirstName")]
    public string FirtstName { get; set; } = string.Empty;
    [JsonPropertyName("LastName")]
    public string LastName{get;set;} = string.Empty;
   
}