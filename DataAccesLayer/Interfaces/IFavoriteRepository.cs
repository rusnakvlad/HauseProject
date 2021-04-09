using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IFavoriteRepository
    {
        public IEnumerable<Favorite> GetAllFavoritesByUserId(int userId);

        public void AddNewFavorite(Favorite favorite);

        public void RemoveFavorite(int userId, int adId);
    }
}
