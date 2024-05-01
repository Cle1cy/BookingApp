using BookingApp_API.Models;

namespace BookingApp_API.Interfaces;
public interface IUserRepository{
    //GET
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetUserAsync(string mail);
    //SET   
    Task<bool> CreateUserAsync(User OneUser);
    //UPDATE
    Task<bool> UpdateUserMailAsync(string mail, string targetMail);
    Task<bool> UpdateUserPasswordAsync(string password, string mail);
    Task<bool> UpdateUserFirstNameAsync(string firtstName, string mail);
    Task<bool> UpdateUserLastNameAsync(string lastName, string mail);
    //DELTE
    //For delete the acount
    Task<bool> DeleteUserAsync(string password, string mail);
    //MORE
    Task<bool> ExistUserAsyn(string mail);
}