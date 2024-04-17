using Microsoft.AspNetCore.Identity;
using ToDoApp_API.Models;

namespace ToDoApp_App.Models;

public class User{

    public int Id { get; set;}
    public string Password{get; set;}
    public string Mail{get; set;}
    public string FirtstName{get; set;}
    public string LastName{get;set;}
    public ICollection<Note> Notes{get; set;}

}