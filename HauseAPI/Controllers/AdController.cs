using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;
namespace HauseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdController : Controller
    {
        private readonly IAdServices adService = new AdServices();

        // get ad by id
        [HttpGet("/ad/{id}")]
        public AdInfoDTO GetAddDTOByID(int id)
        {
            return adService.GetAdById(id);
        }

        // register new user
        [HttpPost]
        public void AddNewAdd ([FromBody]CreateAdDTO createAdDTO)
        {
            adService.AddNewAd(createAdDTO);
        }

    }
}
