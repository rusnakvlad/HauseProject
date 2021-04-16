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
        /*--------------------Common Methods from Generic repository--------------------*/
        public IEnumerable<AdInfoDTO> GetAllAds()
        {
            var allAds = Database.AdRepository.GetAll();
            
            foreach (var ad in allAds)
            {
                List<TagDTO> tagsDTOs = new ();
                List<ImageDTO> imageDTOs = new ();
                // Get Tags
                foreach (var item in ad.tags)
                    tagsDTOs.Add(new TagDTO() { _Tag = item.Tag_ });
                
                // Get Images
                foreach (var item in ad.images)
                    imageDTOs.Add(new ImageDTO() { ImageURL = item.ImageUrl });

                var owenerOfAd = Database.UserRepository.GetById(ad.OwnerId);
                yield return new AdInfoDTO()
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
                    OwnerPhone = owenerOfAd.Phone,
                    tags = tagsDTOs,
                    images = imageDTOs
                };
            }
        }

        public AdInfoDTO GetAdById(int id)
        {
            var ad = Database.AdRepository.GetById(id);
            var owenerOfAd = Database.UserRepository.GetById(ad.OwnerId);
            List<TagDTO> tagsDTOs = new List<TagDTO>();
            List<ImageDTO> imageDTOs = new List<ImageDTO>();
            // Get Tags
            foreach (var item in ad.tags)
                tagsDTOs.Add(new TagDTO() { _Tag = item.Tag_ });
            
            // Get Images
            foreach (var item in ad.images)
                 imageDTOs.Add(new ImageDTO() { ImageURL = item.ImageUrl });
            
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
                OwnerPhone = owenerOfAd.Phone,
                tags = tagsDTOs,
                images = imageDTOs
            };
        }

        public void AddNewAd(AdCreateDTO createAdDTO)
        {
            Database.AdRepository.Add(ConvertToAd.FromCreateAddInfoDTO(createAdDTO));
        }

        public void DeleteAdById(int id)
        {
            Database.AdRepository.DeleteById(id);
        }

        public void UpdateAd(AdEdit editAdDTO)
        {
            Database.AdRepository.Update(ConvertToAd.FromEditAddInfoDTO(editAdDTO));
            
        }

        public void SetFavorite(int userId, int adId)
        {
            Database.FavoriteRepository.Add(new Favorite(userId, adId));
        }

        public void SetForCompare(int userId, int adId)
        {
            Database.ForCompareRepository.Add(new ForCompare(userId, adId));
        }

        /*------------------------------Individual methods------------------------------*/
    }
}
