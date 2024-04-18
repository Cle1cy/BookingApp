using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.ComponentModel;
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
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [JsonPropertyName("dateOnly")]
    public DateOnly DateOnly { get; set; } = DateOnly.FromDateTime(DateTime.Now);

}
