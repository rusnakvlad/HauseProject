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
    public class ForCompareController : Controller
    {
        private readonly IForCompareServices forCompareServices;

        public ForCompareController(IForCompareServices forCompareServices) => this.forCompareServices = forCompareServices;
        
        // set(add) new comparision for user
        [HttpPost("{userId}/{adId}")]
        public void SetNewForCompare(int userId, int adId)
        {
            forCompareServices.SetForCompare(userId, adId);
        }
        // get all user compares by user and ad id
        [HttpGet("{userId}")]
        public IEnumerable<ForCompareDTO> GetUserFavoritesAds(int userId)
        {
            return forCompareServices.GetAllComparesByUserId(userId);
        }

        // Delete Compare by useId and adId
        [HttpDelete("{userId}/{adId}")]
        public void DeleteCompare(int userId, int adId)
        {
            forCompareServices.RemoveCopareByUserIdAndAdId(userId, adId);
        }
    }
}
