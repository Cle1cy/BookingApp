﻿using Microsoft.AspNetCore.Mvc;
using ToDoApp_API.Helpers;
using ToDoApp_API.Services;
using ToDoApp_App.Models;

namespace ToDoApp_API.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly UserService _userService;

        public UserControllers(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            try
            {
                User queryResult = await _userService.CreateUserAsync(user);

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