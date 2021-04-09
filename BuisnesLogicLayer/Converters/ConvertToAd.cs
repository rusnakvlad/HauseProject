﻿using System;
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
        public static Ad FromCreateAddInfoDTO(CreateAdDTO createAdDTO)
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
               // images = createAdDTO.Images,
               // tags = createAdDTO.Tags
            };
        }
    }
}