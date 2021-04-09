using System;
using System.Collections.Generic;
using System.Text;
using BuisnesLogicLayer.DTO;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.Converters;
using DataAccesLayer.Repositories;
using System.Linq;
using DataAccesLayer.EF;
namespace BuisnesLogicLayer.Services
{
    public class UserServices : IUserServices
    {
        private IUnitOfWork Database = new UnitOfWork(
            new AdRepository(new AppDBContext()),
            new CommentRepository(new AppDBContext()),
            new FavoriteRepository(new AppDBContext()),
            new ForCompareRepository(new AppDBContext()),
            new ImageRepository(new AppDBContext()),
            new TagRepository(new AppDBContext()),
            new UserRepository(new AppDBContext())        
            );

        public void DeleteUser(UserProfileDTO userInfoDTO)
        {
            throw new NotImplementedException();
        }

        public void EditUser(UserProfileDTO userInfoDTO)
        {
            throw new NotImplementedException();
        }

        public User GetUserByAdId(int adId)
        {
            var ad = Database.AdRepository.GetAddById(adId);
            var owenerOfAd = Database.UserRepository.GetUserById(ad.OwnerId);
            return owenerOfAd;
        }

        public UserProfileDTO GetUserProfileById(int id)
        {
            var user = Database.UserRepository.GetUserById(id);
            var comments = Database.CommentRepository.GetComments().Where(comment => comment.UserID == id).Count();
            var ads = Database.AdRepository.GetAds().Where(ad => ad.OwnerId == id).Count();
            return new UserProfileDTO()
            {
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Email = user.Email,
                AdsAmount = ads,
                ComentsAmount = comments,
                Password = user.Password
            };
        }

        public void LogIn(UserLogInDTO userLogInDTO)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            Database.UserRepository.AddNewUser(ConvertToUser.FromRgisterDTO(userRegisterDTO));
        }
    }
}
