namespace ToDoApp_API.Models;

public class Notes{

    public int Id { get; set; }
    public string title{ get; set;}
    public string Description { get; set;}
    public int state { get; set;}
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set;} = DateTime.Now;

    
}
