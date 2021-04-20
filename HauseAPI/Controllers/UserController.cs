using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.EF;
namespace HauseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        
        public UserController(IUserServices userServices) => this.userServices = userServices;

        // Get All Users Profiles
        [HttpGet]
        public IEnumerable<UserProfileDTO> GetAllUsersProfiles()
        {
            return userServices.GetAllUsersProfiles();
        }
        // Get User Profile by id
        [HttpGet("/user/{id}")]
        public UserProfileDTO GetUserProfileDTOById(int id)
        {
           return userServices.GetUserProfileById(id);
        }

        // Register(Add) new user
        [HttpPost]
        public void RegisterUser([FromBody]UserRegisterDTO userRegisterDTO)
        {
            userServices.RegisterUser(userRegisterDTO);
        }

        // Delete user by id
        [HttpDelete("{id}")]
        public void DeleteUserById(int id)
        {
            userServices.DeleteUserById(id);
        }

        // Edit user
        [HttpPut]
        public void EditUser([FromBody] UserEditDTO userEditDTO)
        {
            userServices.UpdateUser(userEditDTO);
        }
    }
}
