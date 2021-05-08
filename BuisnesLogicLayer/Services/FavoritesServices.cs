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

        public async Task<IEnumerable<AdShortInfoDTO>> GetAllFavoritesByUserId(string userId)
        {
            var favorites = await Database.FavoriteRepository.GetAllFavoritesByUserId(userId);
            List<AdShortInfoDTO> adShortInfoDTOs = new();
            foreach (var favorite in favorites)
            {
                var ad = await Database.AdRepository.GetById(favorite.AdID);
                adShortInfoDTOs.Add(new AdShortInfoDTO()
                {
                    Id = ad.ID,
                    PurchaseOportunity = ad.PurchaseOportunity,
                    HouseYear = ad.HouseYear,
                    Balkon = ad.Balkon,
                    OwnerId = ad.OwnerId,
                    Price = ad.Price,
                    HouseType = ad.HouseType,
                    RoomNumber = ad.RoomNumber,
                    Status = ad.Status,
                    images = ConvertToImageListDTO.FromImageList(ad.images)
                });
            }
            return adShortInfoDTOs;
        }

        public async Task RemoveFavoriteByUserIdAndAdId(string userId, int adId)
        {
            await Database.FavoriteRepository.RemoveFavoriteByUserIdAndAdId(userId, adId);
        }

        public async Task SetFavorite(string userId, int adId)
        {
            await Database.FavoriteRepository.Add(new Favorite(userId, adId));
        }
    }
}

