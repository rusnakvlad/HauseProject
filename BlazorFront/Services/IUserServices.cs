﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
namespace BlazorFront.Services
{
    public interface IUserServices
    {
        public Task<UserProfileDTO> GetUserByEmail(string email);

        public Task<bool> RegisterUser(UserRegisterDTO user);

        public Task<bool> UpdateUser(UserEditDTO user);

        public Task<UserProfileDTO> LogIn(UserLogInDTO user);

        public Task<UserProfileDTO> GetUserById(string Id);
    }
}
