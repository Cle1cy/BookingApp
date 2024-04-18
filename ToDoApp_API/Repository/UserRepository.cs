namespace ToDoApp_API.Repository;

using Microsoft.EntityFrameworkCore;
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

    public UserRepository (DBContext context)
    {
        _dbContext = context;
    }
    public async Task<User> GetUserAsync(string mail)
    {
        User user = new();
        var queryResult = await _dbContext.User
                .Where(u => u.Mail == mail)
                .FirstOrDefaultAsync();
        if (queryResult is not null)
            user = queryResult;
        return user;
    }
    public async Task<ICollection<User>> GetUserAsync()
    {
        return await _dbContext.User
                .ToListAsync();
    }
  
    public async Task<bool> CreateUserAsync(User OneUser)
    {

        User? exist = await _dbContext.User
                .Where(u => u.Mail == OneUser.Mail)
                .FirstOrDefaultAsync();

        if (exist is not null) 
            throw new DbOperationException("Couldn't insert. Account already exist.");
        try
        {
            var queryResult = await _dbContext
                    .AddAsync(OneUser);

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
        User? user = await _dbContext.User
            .Where(u => u.Password == password)
            .FirstOrDefaultAsync();

        if(user == null) throw new DbOperationException("Couldn't delete, user doesn't exist");
        try
        {
            _dbContext.User.Remove(user);
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