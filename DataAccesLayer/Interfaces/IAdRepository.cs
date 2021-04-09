using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IAdRepository
    {
        public IEnumerable<Ad> GetAds();
        public Ad GetAddById(int id);
        public void AddNewAd(Ad ad);
        
    }
}
