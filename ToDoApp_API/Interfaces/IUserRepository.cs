using ToDoApp_App.Models;

namespace ToDoApp_API.Interfaces;
public interface IUserRepository{
    // GETTERS
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetUserAsync(int id);
    //SETTERS   
    Task<bool> CreateUserAsync(
        string password,
        string mail,
        string firstName,
        string lastName
    );
    //UPDATES
    Task<User> UpdateUserMailAsync(string mail);
    Task<User> UpdateUserPasswordAsync(string password);
    Task<User> UpdateUserFirstNameAsync(string firtstName);
    Task<User> UpdateUserLastNameAsync(string lastName);
    //DELETS
    //For delete the acount
    Task<User> DeleteUserAsync(
        string password, 
        bool accept
    );
    //Validate user exist
    Task<bool> ExistUserAsync(int id);
}