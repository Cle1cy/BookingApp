using ToDoApp_App.Models;

namespace ToDoApp_API.Interfaces;
public interface IUserRepository{
    // GETTERS
    Task<ICollection<User>> GetUserAsync();
    Task<User> GetUserAsync(string mail);
    //SETTERS   
    Task<bool> CreateUserAsync(User OneUser);
    //UPDATES
    Task<bool> UpdateUserMailAsync(string mail);
    Task<bool> UpdateUserPasswordAsync(string password);
    Task<bool> UpdateUserFirstNameAsync(string firtstName);
    Task<bool> UpdateUserLastNameAsync(string lastName);
    //DELETS
    //For delete the acount
    Task<bool> DeleteUserAsync(string password);
}