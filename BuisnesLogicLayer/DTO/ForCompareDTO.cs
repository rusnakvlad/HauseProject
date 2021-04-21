﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTO
{
    public class ForCompareDTO
    {
        // not displayed
        public int Id { get; set; }
        public int OwnerId { get; set; }
        
        // displayed
        public int Price { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string HouseType { get; set; }
        public int AreaOfHouse { get; set; }
        public int FloorAmount { get; set; }
        public int RoomNumber { get; set; }
        public int HouseYear { get; set; }
        public bool Pool { get; set; }
        public bool Balkon { get; set; }
        public bool PurchaseOportunity { get; set; }
        public IEnumerable<ImageEditInfoDTO> images { get; set; }
    }
}
