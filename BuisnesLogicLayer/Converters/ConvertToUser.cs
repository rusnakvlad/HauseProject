using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Converters
{
    public static class ConvertToUser
    {
        public static User FromRgisterDTO(UserRegisterDTO DTO)
        {
            return new User()
            {
                Name = DTO.Name,
                Surname = DTO.Surname,
                Phone = DTO.Phone,
                Email = DTO.Email,
                AdminRights = false,
                Password = DTO.Password
            };
        }

        public static User FromUserEditDTO(UserEditDTO DTO)
        {
            return new User()
            {
                ID = DTO.Id,
                Name = DTO.Name,
                Surname = DTO.Surname,
                Phone = DTO.Phone,
                Email = DTO.Email,
                AdminRights = false,
                Password = DTO.Password
            };
        }
    }
}
