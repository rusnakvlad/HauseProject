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
    public class AdServices : IAdServices
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

        public void AddNewAd(CreateAdDTO createAdDTO)
        {
            Database.AdRepository.AddNewAd(ConvertToAd.FromCreateAddInfoDTO(createAdDTO));
        }

        public AdInfoDTO GetAdById(int id)
        {
            var ad = Database.AdRepository.GetAddById(id);
            var owenerOfAd = Database.UserRepository.GetUserById(ad.OwnerId);
            return new AdInfoDTO()
            {
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
                Status = ad.Status,
                Description = ad.Description,
                OwnerEmail = owenerOfAd.Email,
                OwnerPhone = owenerOfAd.Phone
            };
        }
    }
}
