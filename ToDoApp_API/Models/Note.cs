using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ToDoApp_API.Models;

public class Note{

    public int Id { get; set; } = 0;
    public string title{ get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    public int state { get; set; } = 0;
    public string StartDate { get; set; } = string.Empty;
    public string DateOnly { get; set;} = string.Empty;

    
}
