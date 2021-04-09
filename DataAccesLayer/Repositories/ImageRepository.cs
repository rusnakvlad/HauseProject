using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;

namespace DataAccesLayer.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private AppDBContext context;
        public ImageRepository(AppDBContext context) => this.context = context;

        public void AddNewImage(Image image)
        {
            context.Images.Add(image);
            context.SaveChanges();
        }

        public IEnumerable<Image> GetAllAdsImagesByAdId(int adId)
        {
            return context.Images.ToList().Where(img => img.AdID == adId);
        }

        public void RemoveImageById(int imageId)
        {
            var imageToRemove = context.Images.Find(imageId);
            context.Images.Remove(imageToRemove);
            context.SaveChanges();
        }
    }
}
