
using ToDoApp_API.Helpers;
using ToDoApp_API.Interfaces;
using ToDoApp_App.Models;

namespace ToDoApp_API.Services
{
    public class Userervice
    {
        IUserRepository _userRepository;

        public Userervice(IUserRepository userRepository) 
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
            if (queryResult.Id !> 0)
                throw new AppValidationException($"Couldn't fount user with the mail: {mail}");
            return queryResult;
        }
        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _userRepository.GetUserAsync();
        }

        public async Task<bool> DeleteUserAsync(string password)
        {
            bool queryResult = await _userRepository.DeleteUserAsync(password);
            if (!queryResult) throw new AppValidationException("Operation executed but wasn't changes");
            return queryResult;
        }

    }
}
