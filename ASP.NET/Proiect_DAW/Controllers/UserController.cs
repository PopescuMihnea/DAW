using Proiect_DAW.Models.Constants;
using Proiect_DAW.Repositories;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();

            return Ok(new { users });
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = new User();

            user = await _repository.User.GetByIdAsync(id);

            _repository.User.Delete(user);

            await _repository.SaveAsync();

            return Ok(new UserDTO(user));
        }
    }
}
