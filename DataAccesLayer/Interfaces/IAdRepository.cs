using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IAdRepository //: IGenericRepository<Ad>
    {
        IEnumerable<Ad> GetAll();

        Ad GetById(int id);

        void Add(Ad entity);

        void Update(Ad entity);

        void Delete(Ad entity);

        void DeleteById(int id);

        IEnumerable<Ad> GetAdsByUserId(int adId);

        IEnumerable<Ad> GetAdsByOptions(Dictionary<string, string> filter);

        void SetFavorite(int userId, int adId);

        void SetForCompare(int userId, int adId);
    }
}
