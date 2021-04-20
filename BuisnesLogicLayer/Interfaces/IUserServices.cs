using System;
using System.Collections.Generic;
using System.Text;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Enteties;

namespace BuisnesLogicLayer.Interfaces
{
    public interface IUserServices
    {
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<UserProfileDTO> GetAllUsersProfiles();
        public UserProfileDTO GetUserProfileById(int id);
        public void RegisterUser(UserRegisterDTO userRegisterDTO); // AddNewUser
        public void DeleteUserById(int id);
        public void UpdateUser(UserEditDTO userEditDTO);

        /*------------------------------Individual methods------------------------------*/
        public bool LogIn(UserLogInDTO userLogInDTO);
        public void LogOut();
    }
}
