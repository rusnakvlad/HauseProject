using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Repositories
{
    public class TagRepository :GenericRepository<Tag>, ITagRepository
    {
        private AppDBContext context;
        public TagRepository(AppDBContext context) : base(context) => this.context = context;

        public async Task<IEnumerable<Tag>> GetTagsFromAdByAdsId(int adId)
        {
            return await context.Tags.ToListAsync();
        }
    }
}
