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
using System.Threading.Tasks;

namespace BuisnesLogicLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork Database;

        public UserServices(IUnitOfWork unitOfWork) => Database = unitOfWork;

        public async Task<bool> DeleteUserById(string id)
        {
           return await Database.UserRepository.DeleteById(id);
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAllUsersProfiles()
        {
            var users = await Database.UserRepository.GetAll();
            List<UserProfileDTO> uesrsProfiles = new();
            foreach (var user in users)
            {
                var comments = await Database.CommentRepository.GetAll();
                var commentsCount = comments.Where(comment => comment.UserID == user.Id).Count();
                var ads = await Database.AdRepository.GetAll();
                var adsCount = ads.Where(ad => ad.OwnerId == user.Id).Count();
                uesrsProfiles.Add(new UserProfileDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Phone = user.PhoneNumber,
                    Email = user.Email,
                    AdsAmount = adsCount,
                    ComentsAmount = commentsCount,
                    Password = user.PasswordHash,
                });
            }
            return uesrsProfiles.ToList();
        }

        public async Task<UserProfileDTO> GetUserProfileById(string id)
        {
            var user = await Database.UserRepository.GetById(id);
            var comments =await Database.CommentRepository.GetAll();
            var commentsCount = comments.Where(comment => comment.UserID == user.Id).Count();
            var ads = await Database.AdRepository.GetAll();
            var adsCount = ads.Where(ad => ad.OwnerId == id).Count();
            return new UserProfileDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.PhoneNumber,
                Email = user.Email,
                AdsAmount = adsCount,
                ComentsAmount = commentsCount,
                Password = user.PasswordHash
            };
        }

        public async Task<UserProfileDTO> GetUserProfileByEmail(string email)
        {
            var user = await Database.UserRepository.GetByEmail(email);
            var comments = await Database.CommentRepository.GetAll();
            var commentsCount = comments.Where(comment => comment.UserID == user.Id).Count();
            var ads = await Database.AdRepository.GetAll();
            var adsCount = ads.Where(ad => ad.OwnerId == user.Id).Count();
            return new UserProfileDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.PhoneNumber,
                Email = user.Email,
                AdsAmount = adsCount,
                ComentsAmount = commentsCount,
                Password = user.PasswordHash
            };
        }

        public async Task<UserProfileDTO> LogIn (UserLogInDTO userLogin)
        {
            var user = await Database.UserRepository.LogIn(userLogin.Email, userLogin.Password);
            return new UserProfileDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.PhoneNumber,
                Email = user.Email,
                Password = user.PasswordHash
            };
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
           return await Database.UserRepository.Add(ConvertToUser.FromRgisterDTO(userRegisterDTO));
        }

        public async Task<bool> UpdateUser(UserEditDTO userEditDTO)
        {
            return await Database.UserRepository.Update(ConvertToUser.FromUserEditDTO(userEditDTO));
        }
    }
}
