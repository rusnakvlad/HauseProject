using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class TagRepository :GenericRepository<Tag>, ITagRepository
    {
        private AppDBContext context;
        public TagRepository(AppDBContext context) : base(context) => this.context = context;

        public IEnumerable<Tag> GetTagsFromAdByAdsId(int adId)
        {
            return context.Tags.ToList();
        }
    }
}
