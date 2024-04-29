using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BookingApp_API.Dto;
using BookingApp_API.Helpers;
using BookingApp_API.Services;
using BookingApp_API.Models;

namespace BookingApp_API.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserControllers(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{mail}")]
        public async Task<IActionResult> GetUserAsync(string mail)
        {
            try
            {
                UserDto queryResul = _mapper.Map<UserDto>
                        (await _userService.GetUserAsync(mail));
                return Ok(queryResul);

            } catch (AppValidationException error)
            {
                return NotFound(error.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            ICollection<UserDto> queryResul = _mapper.Map<ICollection<UserDto>>
                (await _userService.GetUsersAsync());
            return Ok(queryResul);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserDto user)
        {
            try
            {
                User userMapper = _mapper.Map<User>(user);
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _userService.CreateUserAsync(userMapper));

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

        [HttpPut("mail/{mail}/{targetMail}")]
        public async Task<IActionResult> UpdateUserMailAsync(string mail, string taregetMail)
        {
            try
            {
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _userService.UpdateUserMailAsync(mail, taregetMail));
                return Ok(queryResult);
            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return NotFound($"Ops! Someting went wrong in DB Operation: {error.Message}");
            }
        }

        [HttpPut("password/{mail}/{password}")]
        public async Task<IActionResult> UpdateUserPasswordAsync(string password, string mail)
        {
            try
            {
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _userService.UpdateUserPasswordAsync(password, mail));
                return Ok(queryResult);
            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return NotFound($"Ops! Someting went wrong in DB Operation: {error.Message}");
            }
        }

        [HttpPut("firstname/{mail}/{firstName}")]
        public async Task<IActionResult> UpdateUserFirstNameAsync(string firstName, string mail)
        {
            try
            {
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _userService.UpdateUserFirstNameAsync(firstName, mail));
                return Ok(queryResult);
            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return NotFound($"Ops! Someting went wrong in DB Operation: {error.Message}");
            }
        }

        [HttpPut("lastname/{mail}/{lastName}")]
        public async Task<IActionResult> UpdateUserLastNameAsync(string lastName, string mail)
        {
            try
            {
                UserDto queryResult = _mapper.Map<UserDto>
                    (await _userService.UpdateUserLastNameAsync(lastName, mail));
                return Ok(queryResult);
            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return NotFound($"Ops! Someting went wrong in DB Operation: {error.Message}");
            }
        }

        [HttpDelete("{password}")]
        public async Task<IActionResult> DeleteUserAsync(string password, string mail)
        {
            try
            {
                bool QueryResult = await _userService.DeleteUserAsync(password, mail);
                return Ok(QueryResult);

            }
            catch (AppValidationException error)
            {
                return BadRequest($"Ops! Valitadion Error: {error.Message}");
            }
            catch (DbOperationException error)
            {
                return NotFound($"Ops! Someting went wrong in DB Operation: {error.Message}");
            }
        }
    }

}
