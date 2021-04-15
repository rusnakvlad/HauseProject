using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        public IEnumerable<Tag> GetTagsFromAdByAdsId(int adId);
    }
}
