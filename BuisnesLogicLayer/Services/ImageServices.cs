using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogicLayer.DTO;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer.Interfaces;

namespace BuisnesLogicLayer.Services
{
    public class ImageServices : IImageServices
    {
        private IUnitOfWork Database;
        public ImageServices(IUnitOfWork unitOfWork) => Database = unitOfWork;

        public async Task<IEnumerable<ImageEditInfoDTO>> GetImagesByAdId(int adId)
        {
            List<ImageEditInfoDTO> imageDTOs = new List<ImageEditInfoDTO>();
            var images = await Database.ImageRepository.GetAllAdsImagesByAdId(adId);

            foreach (var item in images)
            {
                imageDTOs.Add(new ImageEditInfoDTO() { ImageFile = item.ImageFile, Id = item.ID, AdId = item.AdID });
            }

            return imageDTOs;
        }
    }
}
