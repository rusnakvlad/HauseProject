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
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private AppDBContext context;
        public ImageRepository(AppDBContext context) : base(context) => this.context = context;


        public async Task<IEnumerable<Image>> GetAllAdsImagesByAdId(int adId)
        {
            return await context.Images.Where(img => img.AdID == adId).ToListAsync();
        }

        public async Task RemoveImageById(int imageId)
        {
            var imageToRemove = context.Images.Find(imageId);
            context.Images.Remove(imageToRemove);
            await context.SaveChangesAsync();
        }
    }
}
