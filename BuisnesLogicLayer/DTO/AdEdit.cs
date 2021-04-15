﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;

namespace BuisnesLogicLayer.DTO
{
    public class AdEdit
    {
        public int ID { get; set; }
        public int OwnerId { get; set; }
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
        public bool Status { get; set; }
        public string Description { get; set; }
        public List<TagDTO> tags { get; set; }
        public List<ImageDTO> images { get; set; }
    }
}
