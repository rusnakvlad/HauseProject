using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        public IEnumerable<Image> GetAllAdsImagesByAdId(int adId);
    }
}
