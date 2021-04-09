using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Converters
{
    public static class ConvertToUser
    {
        public static User FromRgisterDTO(UserRegisterDTO registerDTO)
        {
            return new User()
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Phone = registerDTO.Phone,
                Email = registerDTO.Email,
                AdminRights = false,
                Password = registerDTO.Password
            };
        }
    }
}
