using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IForCompareRepository
    {
        public IEnumerable<ForCompare> GetAllComparesByUserId(int userId);
        public void RemoveCopare(int userId, int AdId);
        public void AddNewCompare(ForCompare forCompare);
    }
}
