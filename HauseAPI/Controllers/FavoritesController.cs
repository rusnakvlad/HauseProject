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
    public class FavoritesController : Controller
    {
        private readonly IFavoritesServices favoritesServices;

        public FavoritesController(IFavoritesServices favoritesServices) => this.favoritesServices = favoritesServices;

        // get all user favoritres by user and ad id
        [HttpGet("{userId}/{adId}")]
        public IEnumerable<AdShortInfoDTO> GetUserFavoritesAds(int userId)
        {
           return favoritesServices.GetAllFavoritesByUserId(userId);
        }

        // Delete Favorite by useId and adId
        [HttpDelete("{userId}/{adId}")]
        public void DeleteFavorite(int userId, int adId)
        {
            favoritesServices.RemoveFavoriteByUserIdAndAdId(userId, adId);
        }
    }
}
