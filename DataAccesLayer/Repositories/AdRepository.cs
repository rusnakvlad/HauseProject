using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using DataAccesLayer.Interfaces;
using DataAccesLayer.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class AdRepository : IAdRepository
    {
        private AppDBContext context;
        public AdRepository(AppDBContext context) => this.context = context;

        public async Task Add(Ad entity)
        {
            await context.Ads.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Ad entityToDelete)
        {
            if (await context.Ads.AnyAsync(ad => ad == entityToDelete))
            {
                context.Ads.Remove(entityToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            if (await context.Ads.AnyAsync(ad => ad.ID == id))
            {
                var entityToDelete = await context.Ads.FindAsync(id);
                await this.Delete(entityToDelete);
            }
        }

        public async Task<IEnumerable<Ad>> GetAdsByOptions(Dictionary<string, string> filter)
        {
            return await context.Ads.Include(c => c.comments)
                        .Include(i => i.images)
                        .Include(t => t.tags)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Ad>> GetAdsByUserId(string userId)
        {
            if (await context.Ads.AnyAsync(ad => ad.OwnerId == userId))
            {
                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .Where(ad => ad.OwnerId == userId)
                            .ToListAsync();
            }
            else
            {
                throw new Exception($"User with id {userId} has not ads");
            }
        }

        public async Task<IEnumerable<Ad>> GetAll()
        {
            if (await context.Ads.CountAsync() != 0)
            {
                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .ToListAsync();
            }
            else
            {
                throw new Exception("In database are not ahy ads");
            }
        }

        public async Task<Ad> GetById(int id)
        {
            if (await context.Ads.AnyAsync(ad => ad.ID == id))
            {
                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .Where(ad => ad.ID == id)
                            .FirstOrDefaultAsync();
            }
            else
            {
                throw new Exception($"There are not image with id: {id}");
            }
        }

        public async Task Update(Ad ad)
        {
            if (await context.Ads.AnyAsync(dbAd => dbAd == ad))
            {
                context.Ads.Update(ad);
                await context.SaveChangesAsync();
            }
        }
    }
}
