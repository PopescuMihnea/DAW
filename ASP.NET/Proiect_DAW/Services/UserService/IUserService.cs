﻿using Proiect_DAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
