using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogicLayer.DTO
{
    public class AdShortInfoDTO
    {
        // not displayed
        public int ID { get; set; }
        public int OwnerId { get; set; }

        // displayed
        public int Price { get; set; }
        public string HouseType { get; set; }
        public int AreaOfHouse { get; set; }
        public int RoomNumber { get; set; }
        public bool Status { get; set; }
        public IEnumerable<ImageDTO> images { get; set; }
    }
}
