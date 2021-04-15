using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        public IEnumerable<Favorite> GetAllFavoritesByUserId(int userId);

        public void RemoveFavoriteByUserIdAndAdId(int userId, int adId);
    }
}
