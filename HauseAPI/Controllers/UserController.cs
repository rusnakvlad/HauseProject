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
        private readonly IUserServices userServices = new UserServices();
       // public UserController(IUserServices userServices) => this.userServices = userServices;

        [HttpGet("/user/{id}")]
        public UserProfileDTO GetUserProfileDTOById(int id)
        {
           return userServices.GetUserProfileById(id);
        }
    }
}
