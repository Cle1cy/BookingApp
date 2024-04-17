using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDoApp_API.Interfaces;

namespace ToDoApp_API.Services
{
    public class UserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {  
            _userRepository = userRepository; 
        }

        public async Task<bool> CreateUserAsync
        (
            string password,
            string mail,
            string firstName,
            string lastName
        )
        {
            if (password == "" || string.IsNullOrWhiteSpace(password))
                
            var queryOperation = await _userRepository
                .CreateUserAsync(password, mail, firstName, lastName);  
                            

        }
    }
}
