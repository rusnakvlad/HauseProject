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
using AutoMapper;

namespace BuisnesLogicLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork Database;
        private readonly IMapper mapper;
        public UserServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            this.mapper = mapper;
        }

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

                var mappedUser = mapper.Map<User, UserProfileDTO>(user);
                mappedUser.AdsAmount = adsCount;
                mappedUser.ComentsAmount = commentsCount;

                uesrsProfiles.Add(mappedUser);
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

            var mappedUser = mapper.Map<User, UserProfileDTO>(user);
            mappedUser.AdsAmount = adsCount;
            mappedUser.ComentsAmount = commentsCount;
            return mappedUser;
        }

        public async Task<UserProfileDTO> GetUserProfileByEmail(string email)
        {
            var user = await Database.UserRepository.GetByEmail(email);
            var comments = await Database.CommentRepository.GetAll();
            var commentsCount = comments.Where(comment => comment.UserID == user.Id).Count();
            var ads = await Database.AdRepository.GetAll();
            var adsCount = ads.Where(ad => ad.OwnerId == user.Id).Count();

            var mappedUser = mapper.Map<User, UserProfileDTO>(user);
            mappedUser.AdsAmount = adsCount;
            mappedUser.ComentsAmount = commentsCount;
            return mappedUser;
        }

        public async Task<UserProfileDTO> LogIn (UserLogInDTO userLogin)
        {
            var user = await Database.UserRepository.LogIn(userLogin.Email, userLogin.Password);
            var mappedUser = mapper.Map<User, UserProfileDTO>(user);
            return mappedUser;
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
