using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAccesLayer.Enteties
{
    public class Image
    {
        
        ////////////////////////////////////////////////
        public Ad ad { get; set; }
        ////////////////////////////////////////////////
        public int ID { get; set; }
        public int AdID { get; set; }
        public string ImageUrl { get; set; }
        public Image(int AdsID, string ImageUrl)
        {
            this.AdID = AdsID;
            this.ImageUrl = ImageUrl;
        }
        public Image() { }
    }
}
