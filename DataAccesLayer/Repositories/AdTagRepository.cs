using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;

namespace DataAccesLayer.Repositories
{
    public class AdTagRepository : IAdTagRepository
    {
        private AppDBContext context;
        public AdTagRepository(AppDBContext context) => this.context = context;
        public IEnumerable<Tag> GetTagsFromAdByAdsId(int adId)
        {
            Ad _ad = context.Ads.Find(adId);
            List<Tag> tags = new List<Tag>();
            foreach (var tag in _ad.tags)
            {
                tags.Add(tag);
            }
            return tags;
        }
    }
}
