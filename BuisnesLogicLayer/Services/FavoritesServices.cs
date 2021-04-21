using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.EF;
using BuisnesLogicLayer.DTO;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer;
using DataAccesLayer.Interfaces;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.Converters;
using DataAccesLayer.Repositories;
namespace BuisnesLogicLayer.Services
{
    public class FavoritesServices : IFavoritesServices
    {
        private IUnitOfWork Database;

        public FavoritesServices(IUnitOfWork unitOfWork) => Database = unitOfWork;

        public IEnumerable<AdShortInfoDTO> GetAllFavoritesByUserId(int userId)
        {
            var favorites = Database.FavoriteRepository.GetAllFavoritesByUserId(userId);
            foreach (var favorite in favorites)
            {
                var ad = Database.AdRepository.GetById(favorite.AdID);
                yield return new AdShortInfoDTO()
                {
                    ID = ad.ID,
                    OwnerId = ad.OwnerId,
                    Price = ad.Price,
                    HouseType = ad.HouseType,
                    RoomNumber = ad.RoomNumber,
                    Status = ad.Status,
                    images = ConvertToImageListDTO.FromImageList(ad.images)
                };
            }
        }

        public void RemoveFavoriteByUserIdAndAdId(int userId, int adId)
        {
            Database.FavoriteRepository.RemoveFavoriteByUserIdAndAdId(userId, adId);
        }

        public void SetFavorite(int userId, int adId)
        {
            Database.FavoriteRepository.Add(new Favorite(userId, adId));
        }
    }
}

