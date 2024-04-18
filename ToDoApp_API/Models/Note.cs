namespace ToDoApp_API.Models;

public class Note{

    public int Id { get; set; } = 0;
    public string title{ get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    public int state { get; set; } = 0;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set;} = DateTime.Now;

    
}
