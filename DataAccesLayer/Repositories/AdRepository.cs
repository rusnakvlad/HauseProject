using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories
{
    public class AdRepository : IAdRepository
    {
        private AppDBContext context;
        public AdRepository(AppDBContext context) => this.context = context;

        public void Add(Ad entity)
        {
            context.Ads.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Ad entity)
        {
            context.Ads.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entityToDelete = context.Ads.Find(id);
            context.Ads.Remove(entityToDelete);
            context.SaveChanges();
        }

        public IEnumerable<Ad> GetAdsByOptions(Dictionary<string, string> filter)
        {
            throw new Exception();
        }

        public IEnumerable<Ad> GetAdsByUserId(int userId)
        {
            return context.Ads.Include(c => c.comments)
                        .Include(i => i.images)
                        .Include(t => t.tags)
                        .ToList().Where(ad => ad.OwnerId == userId);
        }

        public IEnumerable<Ad> GetAll()
        {
            return context.Ads.Include(c => c.comments)
                        .Include(i => i.images)
                        .Include(t => t.tags)
                        .ToList();
        }

        public Ad GetById(int id)
        {
            return context.Ads.Include(c => c.comments)
                        .Include(i => i.images)
                        .Include(t => t.tags)
                        .ToList().Where(ad => ad.ID == id)
                        .FirstOrDefault();
        }

        public void SetFavorite(int userId, int adId)
        {
            context.Favorites.Add(new Favorite(userId, adId));
        }

        public void SetForCompare(int userId, int adId)
        {
            context.ForCompares.Add(new ForCompare(userId, adId));
        }

        public void Update(Ad entity)
        {
            context.Ads.Update(entity);
        }
    }
}
