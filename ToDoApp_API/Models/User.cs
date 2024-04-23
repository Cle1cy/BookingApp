using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ToDoApp_App.Models;

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
    [JsonPropertyName("Premiun")]
    public byte Premiun{get; set; } = 0;
    [JsonPropertyName("PaymentDate")]
    public DateTime PaymentDate{ get; set; } = DateTime.MinValue;
    [JsonPropertyName("Tutor")]
    public byte Tutor{ get; set; } = 0;
    [JsonPropertyName("UserDetail")]
    public UserDetails? UserDetail{ get; set; } = null;

    

}