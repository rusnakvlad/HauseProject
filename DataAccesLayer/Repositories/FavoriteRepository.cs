using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using System.Linq;
using DataAccesLayer.EF;
namespace DataAccesLayer.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        public AppDBContext context;
        public FavoriteRepository(AppDBContext context) => this.context = context;

        public IEnumerable<Favorite> GetAllFavoritesByUserId(int userId)
        {
            return context.Favorites.ToList().Where(fav => fav.UserID == userId);
        }

        public void AddNewFavorite(Favorite favorite)
        {
            context.Favorites.Add(favorite);
            context.SaveChanges();
        }

        public void RemoveFavorite(int userId, int adId)
        {
            var favTemp = context.Favorites.ToList().Where(fav => fav.UserID == userId && fav.AdID == adId).FirstOrDefault();
            context.Favorites.Remove(favTemp);
            context.SaveChanges();
        }
    }
}
