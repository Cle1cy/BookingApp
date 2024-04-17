namespace ToDoApp_API.Repository;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp_API.Context;
using ToDoApp_API.Helpers;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

public class UserRepository : IUserRepository
{
    public readonly DBContext _dbContext;

    public UserRepository (DBContext context)
    {
        _dbContext = context;
    }

    public async Task<bool> CreateUserAsync(User OneUser)
    {
        User user = new User()
        {
            Password = OneUser.Password,
            Mail = OneUser.Mail,
            FirtstName = OneUser.FirtstName,
            LastName = OneUser.LastName
        };

        if (!await ExistUserAsync(OneUser.Mail)) 
            throw new DbOperationException("Couldn't insert. Account already exist.");
        try
        {
            var queryResult = await _dbContext
                    .AddAsync(user);

            if (queryResult is not null)
                return true;
            return false;
        }
        catch (DbUpdateException error)
        {
            throw new DbOperationException(error.Message);
        }  
    }

    public async Task<bool> DeleteUserAsync(string password)
    {
        var queryResult = await _dbContext
            .RemoveAsync(password);
    }

    public async Task<bool> ExistUserAsync(string mail)
    {
        var queryResult = await _dbContext.Users
            .Where(u => u.Mail == mail)
            .FirstOrDefaultAsync();
        if(queryResult is not null)
            return true;
        return false;
    }

    public async Task<User> GetUserAsync(string mail)
    {
        User user = new();
        var queryResult = await _dbContext.Users
                .Where(u => u.Mail == mail)
                .FirstOrDefaultAsync();
        if (queryResult is not null)
            user = queryResult;
        return user;
    }

    public Task<ICollection<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserFirstNameAsync(string firtstName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserLastNameAsync(string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserMailAsync(string mail)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserPasswordAsync(string password)
    {
        throw new NotImplementedException();
    }

}