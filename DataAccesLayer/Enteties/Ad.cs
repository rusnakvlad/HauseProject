using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    public class Ad
    {
        public User user { get; set; }
        public List<Comment> comments { get; set; }
        public List<Favorite> favorites { get; set; }
        public List<ForCompare> forCompares { get; set; }
        public List<Tag> tags { get; set; }
        public List<Image> images { get; set; }
//=======================================================================//

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
//=======================================================================//
        public Ad(int Id, int OwnerId, int Price,string Region, string District, string City, string Street, 
            string HouseNumber, string HouseType, int AreaOfHouse, int FloorAmount, int RoomNumber, int HouseYear,
            bool Pool, bool PurchaseOportunity, bool Status, string Description)
        {
            this.ID = Id;
            this.OwnerId = OwnerId;
            this.Price = Price;
            this.Region = Region;
            this.District = District;
            this.City = City;
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.HouseType = HouseType;
            this.AreaOfHouse = AreaOfHouse;
            this.FloorAmount = FloorAmount;
            this.RoomNumber = RoomNumber;
            this.HouseYear = HouseYear;
            this.Pool = Pool;
            this.PurchaseOportunity = PurchaseOportunity;
            this.Status = Status;
            this.Description = Description;
        }

        public Ad() { }
    }
}
