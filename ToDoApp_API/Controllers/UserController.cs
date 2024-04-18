using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp_API.Dto;
using ToDoApp_API.Helpers;
using ToDoApp_API.Services;
using ToDoApp_App.Models;

namespace ToDoApp_API.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly Userervice _Userervice;
        private readonly IMapper _mapper;

        public UserControllers(Userervice Userervice, IMapper mapper)
        {
            _Userervice = Userervice;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto user)
        {
            try
            {
                User userMapper = _mapper.Map<User>(user);
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _Userervice.CreateUserAsync(userMapper));

                return Ok(queryResult);
            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return BadRequest($"Ops! Someting went wrong in DB Operation: {error.Message}");

            }

        }
    }
}
