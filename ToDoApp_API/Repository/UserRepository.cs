namespace ToDoApp_API.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp_API.Context;
using ToDoApp_API.Helpers;
using ToDoApp_API.Interfaces;
using ToDoApp_API.Services;
using ToDoApp_App.Models;

public class UserRepository : IUserRepository
{
    public DBContext _dbContext;
    public UserService _userService;

    public UserRepository (DBContext context, UserService userService)
    {
        _dbContext = context;
        _userService = userService;
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
    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await _dbContext.Users
                .ToListAsync();
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
        if (await _userService.GetUserAsync(OneUser.Mail) is not null) 
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

    public async Task<bool> DeleteUserAsync(string password) //made a override of GetUserAsync
    {
        User? user = await _dbContext.Users
            .Where(u => u.Password == password)
            .FirstOrDefaultAsync();

        if(user == null) throw new DbOperationException("Couldn't delete, user doesn't exist");
        try
        {
            _dbContext.Users.Remove(user);
            int queryResult = await _dbContext.SaveChangesAsync();

            if (queryResult <= 0)
                return false;
            return true;
        }catch(DbUpdateException error)
        {
            throw new DbOperationException(error.Message);
        }

    }

  

    //not implement implemented yet!

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