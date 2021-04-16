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
    public class ForcompareServices : IForCompareServices
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

        public IEnumerable<ForCompareDTO> GetAllComparesByUserId(int userId)
        {
            var favorites = Database.FavoriteRepository.GetAllFavoritesByUserId(userId);
            foreach (var favorite in favorites)
            {
                var ad = Database.AdRepository.GetById(favorite.AdID);
                yield return new ForCompareDTO()
                {
                    Id = ad.ID,
                    OwnerId = ad.OwnerId,
                    Price = ad.Price,
                    Region = ad.Region,
                    District = ad.District,
                    City = ad.City,
                    Street = ad.Street,
                    HouseNumber = ad.HouseNumber,
                    HouseType = ad.HouseType,
                    AreaOfHouse = ad.AreaOfHouse,
                    FloorAmount = ad.FloorAmount,
                    RoomNumber = ad.RoomNumber,
                    HouseYear = ad.HouseYear,
                    Pool = ad.Pool,
                    Balkon = ad.Balkon,
                    PurchaseOportunity = ad.PurchaseOportunity,
                    images = ConvertToImageListDTO.FromImageList(ad.images)
                };
            }
        }

        public void RemoveCopareByUserIdAndAdId(int userId, int AdId)
        {
            Database.ForCompareRepository.RemoveCopareByUserIdAndAdId(userId, AdId);
        }
    }
}
