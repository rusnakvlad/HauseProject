using System;
using System.Collections.Generic;
using System.Text;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Enteties;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.Interfaces
{
    public interface IUserServices
    {
        /*--------------------Common Methods from Generic repository--------------------*/
        public Task<IEnumerable<UserProfileDTO>> GetAllUsersProfiles();
        public Task<UserProfileDTO> GetUserProfileById(string id);
        public Task<bool> RegisterUser(UserRegisterDTO userRegisterDTO); // Add New User
        public Task<bool> DeleteUserById(string id);
        public Task<bool> UpdateUser(UserEditDTO userEditDTO);

        /*------------------------------Individual methods------------------------------*/
        public bool LogIn(UserLogInDTO userLogInDTO);
        public void LogOut();
    }
}
