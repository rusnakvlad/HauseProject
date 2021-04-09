using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class AdRepository : IAdRepository
    {
        private AppDBContext context;
        public AdRepository(AppDBContext context) => this.context = context;

        public Ad GetAddById(int id)
        {
            return context.Ads.ToList().Where(ad => ad.ID == id).FirstOrDefault();
        }

        public void AddNewAd(Ad ad)
        {
            context.Ads.Add(ad);
            context.SaveChanges();
        }

        public IEnumerable<Ad> GetAds()
        {
            return context.Ads.ToList();
        }
    }
}
