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
        private IUnitOfWork Database;

        public ForcompareServices(IUnitOfWork unitOfWork) => Database = unitOfWork;

        public async Task<IEnumerable<ForCompareDTO>> GetAllComparesByUserId(string userId)
        {
            var forCompares = await Database.ForCompareRepository.GetAllComparesByUserId(userId);
            List<ForCompareDTO> forCompareDTOs = new();
            foreach (var coparasion in forCompares)
            {
                var ad = await Database.AdRepository.GetById(coparasion.AdID);
                forCompareDTOs.Add(new ForCompareDTO()
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
                });
            }
            return forCompareDTOs;
        }

        public async Task RemoveCopareByUserIdAndAdId(string userId, int AdId)
        {
           await Database.ForCompareRepository.RemoveCopareByUserIdAndAdId(userId, AdId);
        }

        public async Task SetForCompare(string userId, int adId)
        {
            await Database.ForCompareRepository.Add(new ForCompare(userId, adId));
        }
    }
}
