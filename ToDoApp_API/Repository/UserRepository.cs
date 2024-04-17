namespace ToDoApp_API.Repository;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp_API.Context;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

public class UserRepository : IUserRepository
{
    public readonly DBContext _dbContext;

    public UserRepository (DBContext context)
    {
        _dbContext = context;
    }

    public async Task<bool> CreateUserAsync(string password, string mail, string firstName, string lastName)
    {

        User user = new User()
        {
            Password = password,
            Mail = mail,
            FirtstName = firstName,
            LastName = lastName
        };
        var exist = await _dbContext.Users
                .Where(u => u.Mail == mail)
                .Select(u => u.Mail)
                .FirstOrDefaultAsync();
        if (string.IsNullOrEmpty(exist)) throw new DbOperationException();
        var queryResult = await _dbContext
                .AddAsync(user);

        if (queryResult is not null)
            return true;
        return false;
                
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