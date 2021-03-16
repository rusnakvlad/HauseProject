using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;

namespace DataAccesLayer.Repositories
{
    public class ForCompareRepository : BaseRepository<ForCompare>, IForCompareRepository
    {
        public ForCompareRepository(AppDBContext context) : base(context) { }
    }
}
