using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.Interfaces;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.DTO;
namespace BuisnesLogicLayer.Interfaces
{
    public interface IFavoritesServices
    {
        public void SetFavorite(int userId, int adId);

        public IEnumerable<AdShortInfoDTO> GetAllFavoritesByUserId(int userId);

        public void RemoveFavoriteByUserIdAndAdId(int userId, int adId);
    }
}
