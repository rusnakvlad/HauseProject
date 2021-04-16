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
        private IUnitOfWork Database = new UnitOfWork(
           new AdRepository(new AppDBContext()),
           new CommentRepository(new AppDBContext()),
           new FavoriteRepository(new AppDBContext()),
           new ForCompareRepository(new AppDBContext()),
           new ImageRepository(new AppDBContext()),
           new TagRepository(new AppDBContext()),
           new UserRepository(new AppDBContext())
           );

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
    }
}

