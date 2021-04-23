using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using System.Linq;
using DataAccesLayer.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public AppDBContext context;
        public FavoriteRepository(AppDBContext context) : base(context) => this.context = context;

        public async Task<IEnumerable<Favorite>> GetAllFavoritesByUserId(string userId)
        {
            return await context.Favorites.Where(fav => fav.UserID == userId).ToListAsync();
        }

        public async Task RemoveFavoriteByUserIdAndAdId(string userId, int adId)
        {
            var favTemp = context.Favorites.ToList().Where(fav => fav.UserID == userId && fav.AdID == adId).FirstOrDefault();
            context.Favorites.Remove(favTemp);
            await context.SaveChangesAsync();
        }
    }
}
