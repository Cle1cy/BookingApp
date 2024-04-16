namespace ToDoApp_API.Repository;

using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

public class UserRepository : IUsersRepository
{
    public Task<User> CreateUserAsync(string password, string mail, string firstNamr, string lastNamr)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(string password, bool accept)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserFirstNameAsync(string firtstName)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserLastNameAsync(string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserMailAsync(string mail)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserPasswordAsync(string password)
    {
        throw new NotImplementedException();
    }
}