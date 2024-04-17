namespace ToDoApp_API.Models;

public class Note{

    public int Id { get; set; }
    public string title{ get; set;}
    public string Description { get; set;}
    public int state { get; set;}
    public DateTime StartDate { get; set; }
    public DateTime UpdateDate { get; set;}

    
}
