using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoApp_API.Helpers;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

namespace ToDoApp_API.Services
{
    public class UserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {  
            _userRepository = userRepository; 
        }

        public async Task<User> CreateUserAsync
        (
            string password,
            string mail,
            string firstName,
            string lastName
        )
        {
            if (password.Length !>= 8 ||
                mail.Length !>= 8 ||
                firstName.Length !>= 3 ||
                lastName.Length !>= 3)
            {
                throw new AppValidationException("One of the fields haven't correct format");
            } 

            bool queryOperation = await _userRepository
                .CreateUserAsync(password, mail, firstName, lastName);
            if (!queryOperation)
                throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(mail);
        }

        public async Task<User> GetUserAsync(string mail)
        {
            var queryResult = await _userRepository
                    .GetUserAsync(mail);
            if (queryResult.Id != 0)
                throw new AppValidationException($"Couldn't fount user with the mail: {mail}");
            return queryResult;
        }
    }
}
