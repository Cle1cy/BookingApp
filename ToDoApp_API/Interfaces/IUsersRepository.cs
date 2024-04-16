using ToDoApp_App.Models;

namespace ToDoApp_API.Interfaces;
public interface IUsersRepository{
    // GETTERS
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetUserAsync(int id);
    //SETTERS   
    Task<User> CreateUserAsync(
        string password,
        string mail,
        string firstNamr,
        string lastNamr
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