using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;

namespace DataAccesLayer.Interfaces
{
    public interface IImageRepository
    {
        public void AddNewImage(Image image);
        public void RemoveImageById(int imageId);
        public IEnumerable<Image> GetAllAdsImagesByAdId(int adId);
    }
}
