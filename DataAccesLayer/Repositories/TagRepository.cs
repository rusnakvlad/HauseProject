using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class TagRepository : ITagRepository
    {
        private AppDBContext context;
        public TagRepository(AppDBContext context) => this.context = context;

        public void AddNewTag(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }

        public IEnumerable<Tag> GetTagsFromAdByAdsId(int adId)
        {
            return context.Tags.ToList();
        }
    }
}
