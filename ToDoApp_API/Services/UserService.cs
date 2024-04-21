
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

        public async Task<User> CreateUserAsync(User user)
        {
            if (user.Password.Length <= 8 ||
                user.Mail.Length <= 8 ||
                user.FirtstName.Length <= 3 ||
                user.LastName.Length <= 3)
            {
                throw new AppValidationException("One of the fields haven't correct format");
            } 

            bool queryOperation = await _userRepository
                .CreateUserAsync(user);
            if (!queryOperation)
                throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(user.Mail);
        }

        public async Task<User> GetUserAsync(string mail)
        {
            var queryResult = await _userRepository
                    .GetUserAsync(mail);
            if (queryResult.Id <= 0)
                throw new AppValidationException($"User with: {mail} don't exist");
            return queryResult;
        }
        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<bool> DeleteUserAsync(string password, string mail)
        {
            bool queryResult = await _userRepository.DeleteUserAsync(password, mail);
            if (!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return queryResult;
        }

        public async Task<User> UpdateUserMailAsync(string mail, string targetMail)
        {
            bool queryResult = await _userRepository.UpdateUserMailAsync(mail, targetMail);
            if(!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(mail);
        }
        public async Task<User> UpdateUserPasswordAsync(string password, string mail)
        {
            bool queryResult = await _userRepository.UpdateUserPasswordAsync(password,mail);
            if (!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(mail);
        }
        public async Task<User> UpdateUserFirstNameAsync(string firtstName, string mail)
        {
            bool queryResult = await _userRepository.UpdateUserFirstNameAsync(firtstName, mail);
            if (!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(mail);
        }
        public async Task<User> UpdateUserLastNameAsync(string lastName, string mail)
        {
            bool queryResult = await _userRepository.UpdateUserLastNameAsync(lastName, mail);
            if (!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return await GetUserAsync(mail);
        }
    }
}
