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
    private DBContext _dbContext;

    public UserRepository(DBContext context)
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
   
    public async Task<bool> ExistUserAsyn(string mail)
    {
        var queryResult = await _dbContext.User
                .Where(u => u.Mail == mail)
                .FirstOrDefaultAsync();
        if (queryResult is not null)
            return true;
        return false;
    }

    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await _dbContext.User
                .ToListAsync();
    }

    public async Task<bool> CreateUserAsync(User OneUser)
    {
        if (await ExistUserAsyn(OneUser.Mail)) 
            throw new DbOperationException("Couldn't insert. Account already exist.");
        try
        {
            var queryResult = await _dbContext
                    .AddAsync(OneUser);
            
            if (queryResult is not null)
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
                
            return false;
        }
        catch (DbUpdateException error)
        {
            throw new DbOperationException(error.Message);
        }  
    }

    public async Task<bool> DeleteUserAsync(string password, string mail)
    {
        User? user = await _dbContext.User
            .Where(u => u.Password == password && u.Mail == mail)
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

    public async Task<bool> UpdateUserFirstNameAsync(string firstName, string mail)
    {
        User? queryResult = await _dbContext.User
                .Where(u => u.Mail == mail)
                .FirstOrDefaultAsync();

        if (queryResult is null) throw new DbOperationException("Couldn't update user don't exist");
        try
        {
            queryResult.FirtstName = firstName;
            int update = await _dbContext.SaveChangesAsync();

            if (update <= 0)
                return false;
            return true;

        }catch (DbUpdateException error)
        {
            throw new DbUpdateException(error.Message);
        }
    }

    public async Task<bool> UpdateUserLastNameAsync(string lastName, string mail)
    {
        User? queryResult = await _dbContext.User
        .Where(u => u.Mail == mail)
        .FirstOrDefaultAsync();

        if (queryResult is null) throw new DbOperationException("Couldn't update user don't exist");
        try
        {
            queryResult.LastName = lastName;
            int update = await _dbContext.SaveChangesAsync();

            if (update <= 0)
                return false;
            return true;

        }
        catch (DbUpdateException error)
        {
            throw new DbUpdateException(error.Message);
        }
    }

    public async Task<bool> UpdateUserMailAsync(string mail, string targetMail)
    {
        User? queryResult = await _dbContext.User
            .Where(u => u.Mail == targetMail)
            .FirstOrDefaultAsync();

        if (queryResult is null) throw new DbOperationException("Couldn't update user don't exist");
        try
        {
            queryResult.Mail = mail;
            int update = await _dbContext.SaveChangesAsync();

            if (update <= 0)
                return false;
            return true;

        }
        catch (DbUpdateException error)
        {
            throw new DbUpdateException(error.Message);
        }
    }

    public async Task<bool> UpdateUserPasswordAsync(string password, string mail)
    {
        User? queryResult = await _dbContext.User
            .Where(u => u.Mail == mail)
            .FirstOrDefaultAsync();

        if (queryResult is null) throw new DbOperationException("Couldn't update user don't exist");
        try
        {
            queryResult.Password = password;
            int update = await _dbContext.SaveChangesAsync();

            if (update <= 0)
                return false;
            return true;

        }
        catch (DbUpdateException error)
        {
            throw new DbUpdateException(error.Message);
        }
    }


}