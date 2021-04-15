using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using System.Linq;
using DataAccesLayer.EF;
namespace DataAccesLayer.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public AppDBContext context;
        public FavoriteRepository(AppDBContext context) : base(context) => this.context = context;

        public IEnumerable<Favorite> GetAllFavoritesByUserId(int userId)
        {
            return context.Favorites.ToList().Where(fav => fav.UserID == userId);
        }

        public void RemoveFavoriteByUserIdAndAdId(int userId, int adId)
        {
            var favTemp = context.Favorites.ToList().Where(fav => fav.UserID == userId && fav.AdID == adId).FirstOrDefault();
            context.Favorites.Remove(favTemp);
            context.SaveChanges();
        }
    }
}
