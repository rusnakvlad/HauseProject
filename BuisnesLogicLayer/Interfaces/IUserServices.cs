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
        public void RegisterUser(UserRegisterDTO userRegisterDTO); // create a new user and add to DB
        public void DeleteUser(UserProfileDTO userInfoDTO);
        public void EditUser(UserProfileDTO userInfoDTO);
        public void LogIn(UserLogInDTO userLogInDTO);
        public void LogOut();
        public UserProfileDTO GetUserProfileById(int id);
        public User GetUserByAdId(int adId);
    }
}
