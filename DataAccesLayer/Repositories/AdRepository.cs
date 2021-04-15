using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class AdRepository : GenericRepository<Ad>, IAdRepository
    {
        private AppDBContext context;
        public AdRepository(AppDBContext context) : base(context) => this.context = context;
    }
}
