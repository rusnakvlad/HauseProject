using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class ForCompareRepository : GenericRepository<ForCompare>, IForCompareRepository
    {
        private AppDBContext context;
        public ForCompareRepository(AppDBContext context) : base(context) => this.context = context;


        public IEnumerable<ForCompare> GetAllComparesByUserId(int userId)
        {
            return context.ForCompares.ToList().Where(fc => fc.UserID == userId);
        }

        public void RemoveCopareByUserIdAndAdId(int userId, int AdId)
        {
            var compareToRemove = context.ForCompares.ToList().Where(fc => fc.UserID == userId && fc.AdID == AdId).FirstOrDefault();
            context.ForCompares.Remove(compareToRemove);
            context.SaveChanges();
        }
    }
}
