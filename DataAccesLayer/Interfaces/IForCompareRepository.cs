using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IForCompareRepository : IGenericRepository<ForCompare>
    {
        public IEnumerable<ForCompare> GetAllComparesByUserId(int userId);
        public void RemoveCopareByUserIdAndAdId(int userId, int AdId);
    }
}
