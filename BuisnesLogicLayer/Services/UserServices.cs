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
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<UserProfileDTO> GetAllUsersProfiles()
        {
            var users = Database.UserRepository.GetAll();

            foreach (var user in users)
            {
                var comments = Database.CommentRepository.GetAll().Where(comment => comment.UserID == user.ID).Count();
                var ads = Database.AdRepository.GetAll().Where(ad => ad.OwnerId == user.ID).Count();
                yield return new UserProfileDTO
                {
                    Id = user.ID,
                    Name = user.Name,
                    Surname = user.Surname,
                    Phone = user.Phone,
                    Email = user.Email,
                    AdsAmount = ads,
                    ComentsAmount = comments,
                    Password = user.Password
                };
            }
        }

        public UserProfileDTO GetUserProfileById(int id)
        {
            var user = Database.UserRepository.GetById(id);
            var comments = Database.CommentRepository.GetAll().Where(comment => comment.UserID == id).Count();
            var ads = Database.AdRepository.GetAll().Where(ad => ad.OwnerId == id).Count();
            return new UserProfileDTO()
            {
                Id = user.ID,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Email = user.Email,
                AdsAmount = ads,
                ComentsAmount = comments,
                Password = user.Password
            };
        }

        public void RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            Database.UserRepository.Add(ConvertToUser.FromRgisterDTO(userRegisterDTO));
        }

        public void DeleteUserById(int id)
        {
            Database.UserRepository.DeleteById(id);
        }

        public void UpdateUser(UserEditDTO userEditDTO)
        {
            Database.UserRepository.Update(ConvertToUser.FromUserEditDTO(userEditDTO));
        }
        /*------------------------------Individual methods------------------------------*/

        public void LogIn(UserLogInDTO userLogInDTO)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
