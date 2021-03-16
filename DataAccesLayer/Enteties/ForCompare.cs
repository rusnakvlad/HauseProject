using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    public class ForCompare
    {
        ////////////////////////////////////////////////
        public User user { get; set; }
        public Ad ad { get; set; }
        ////////////////////////////////////////////////
        public int UserID { get; set; }
        public int AdID { get; set; }
        public ForCompare(int UserID, int AdID)
        {
            this.UserID = UserID;
            this.AdID = AdID;
        }

        public ForCompare() { }
    }
}
