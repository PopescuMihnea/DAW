﻿using Proiect_DAW.Models.Constants;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models.Entities;
using Proiect_DAW.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AccountController(
            UserManager<User> userManager,
            IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                return BadRequest("Userul deja exista!");
            }

            var result = await _userService.RegisterUserAsync(dto);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Nu a reusit, bad request");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUser(dto);

            if (token == "wrong password")
            {
                return Unauthorized("Parola gresita");
            }

            if (token == null)
            {
                return Unauthorized("User nu exista");
            }

            return Ok(new { token });
        }
    }
}
