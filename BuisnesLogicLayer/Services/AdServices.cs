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
        private readonly IUnitOfWork Database;

        public AdServices(IUnitOfWork unitOfWork) => Database = unitOfWork;

        /*--------------------Common Methods from Generic repository--------------------*/
        public async Task<IEnumerable<AdInfoDTO>> GetAllAds()
        {
            var allAds = await Database.AdRepository.GetAll();
            var adsDTO = new List<AdInfoDTO>();
            foreach (var ad in allAds)
            {
                List<TagDTO> tagsDTOs = new ();
                List<ImageEditInfoDTO> imageDTOs = new ();
                // Get Tags
                foreach (var item in ad.tags)
                    tagsDTOs.Add(new TagDTO() { _Tag = item.Tag_ });

                // Get Images
                foreach (var item in ad.images)
                    imageDTOs.Add(new ImageEditInfoDTO() { ImageURL = item.ImageUrl, Id = item.ID, AdId = item.AdID });

                var owenerOfAd = await Database.UserRepository.GetById(ad.OwnerId);

                adsDTO.Add(new AdInfoDTO()
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
                    Status = ad.Status,
                    Description = ad.Description,
                    OwnerEmail = owenerOfAd.Email,
                    OwnerPhone = owenerOfAd.PhoneNumber,
                    tags = tagsDTOs,
                    images = imageDTOs
                });
            }
            return adsDTO;
        }

        public async Task<AdInfoDTO> GetAdById(int id)
        {
            var ad = await Database.AdRepository.GetById(id);
            var owenerOfAd = await Database.UserRepository.GetById(ad.OwnerId);
            List<TagDTO> tagsDTOs = new List<TagDTO>();
            List<ImageEditInfoDTO> imageDTOs = new List<ImageEditInfoDTO>();
            // Get Tags
            foreach (var item in ad.tags)
                tagsDTOs.Add(new TagDTO() { _Tag = item.Tag_ });
            
            // Get Images
            foreach (var item in ad.images)
                imageDTOs.Add(new ImageEditInfoDTO() { ImageURL = item.ImageUrl, Id = item.ID, AdId = item.AdID });


            return new AdInfoDTO()
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
                Status = ad.Status,
                Description = ad.Description,
                OwnerEmail = owenerOfAd.Email,
                OwnerPhone = owenerOfAd.PhoneNumber,
                tags = tagsDTOs,
                images = imageDTOs
            };
        }

        public async Task AddNewAd(AdCreateDTO createAdDTO)
        {
            await Database.AdRepository.Add(ConvertToAd.FromCreateAddInfoDTO(createAdDTO));
        }

        public async Task DeleteAdById(int id)
        {
            await Database.AdRepository.DeleteById(id);
        }

        public async Task UpdateAd(AdEdit editAdDTO)
        {
            await Database.AdRepository.Update(ConvertToAd.FromEditAddInfoDTO(editAdDTO));
        }

        /*------------------------------Individual methods------------------------------*/
    }
}
