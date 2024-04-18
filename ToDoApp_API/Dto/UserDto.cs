using System.Text.Json.Serialization;
using ToDoApp_API.Models;

namespace ToDoApp_API.Dto
{
    public class UserDto
    {
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("mail")]
        public string Mail { get; set; } = string.Empty;
        [JsonPropertyName("firstName")]
        public string FirtstName { get; set; } = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

    }
}
