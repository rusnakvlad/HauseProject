using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using BuisnesLogicLayer.DTO;

namespace BuisnesLogicLayer.Converters
{
    public static class ConvertToAd
    {
        public static Ad FromCreateAddInfoDTO(AdCreateDTO createAdDTO)
        {
            return new Ad()
            {
                OwnerId = createAdDTO.OwnerId,
                Price = createAdDTO.Price,
                Region = createAdDTO.Region,
                District = createAdDTO.District,
                City = createAdDTO.City,
                Street = createAdDTO.Street,
                HouseNumber = createAdDTO.HouseNumber,
                HouseType = createAdDTO.HouseType,
                AreaOfHouse = createAdDTO.AreaOfHouse,
                FloorAmount = createAdDTO.FloorAmount,
                RoomNumber = createAdDTO.RoomNumber,
                HouseYear = createAdDTO.HouseYear,
                Pool = createAdDTO.Pool,
                Balkon = createAdDTO.Balkon,
                PurchaseOportunity = createAdDTO.PurchaseOportunity,
                Status = createAdDTO.Status,
                Description = createAdDTO.Description,
                images = ConvertToImageList.FromImageDTOList(createAdDTO.images),
                tags = ConvertToTagList.FromTagDTOList(createAdDTO.tags)
            };
        }

        public static Ad FromEditAddInfoDTO(AdEdit editAdDTO)
        {
            return new Ad()
            {
                ID = editAdDTO.ID,
                OwnerId = editAdDTO.OwnerId,
                Price = editAdDTO.Price,
                Region = editAdDTO.Region,
                District = editAdDTO.District,
                City = editAdDTO.City,
                Street = editAdDTO.Street,
                HouseNumber = editAdDTO.HouseNumber,
                HouseType = editAdDTO.HouseType,
                AreaOfHouse = editAdDTO.AreaOfHouse,
                FloorAmount = editAdDTO.FloorAmount,
                RoomNumber = editAdDTO.RoomNumber,
                HouseYear = editAdDTO.HouseYear,
                Pool = editAdDTO.Pool,
                Balkon = editAdDTO.Balkon,
                PurchaseOportunity = editAdDTO.PurchaseOportunity,
                Status = editAdDTO.Status,
                Description = editAdDTO.Description,
                images = (List<Image>)ConvertToImageList.FromImageDTOList(editAdDTO.images),
                tags = (List<Tag>)ConvertToTagList.FromTagDTOList(editAdDTO.tags)
            };
        }
    }
}
