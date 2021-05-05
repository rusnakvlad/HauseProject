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
                context.Ads.Remove(entityToDelete);
                await context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
                var entityToDelete = await context.Ads.FindAsync(id);
                await this.Delete(entityToDelete);
        }

        public async Task<IEnumerable<Ad>> GetAdsByOptions(AdToCompare adToCompare)
        {
            List<Ad> allAds = await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .ToListAsync();

            List<Ad> resutlAds = new List<Ad>();
            foreach (var ad in allAds)
            {
                if (adToCompare.MaxPrice != 0)
                {
                    if (adToCompare.MaxPrice < ad.Price) break;
                }

                if(adToCompare.Region != "")
                {
                    if (adToCompare.Region != ad.Region) break;
                }

                if (adToCompare.District != "")
                {
                    if (adToCompare.District != ad.District) break;
                }

                if (adToCompare.City != "")
                {
                    if (adToCompare.City != ad.City) break;
                }

                if (adToCompare.HouseType != "" && !adToCompare.HouseTypeNoMatter)
                {
                    if (adToCompare.HouseType != ad.HouseType) break;
                }

                if (adToCompare.MaxAreaOfHouse != 0)
                {
                    if (adToCompare.MaxAreaOfHouse < ad.AreaOfHouse) break;
                }

                if (adToCompare.MaxFloorAmount != 0)
                {
                    if (adToCompare.MaxFloorAmount < ad.FloorAmount) break;
                }

                if (adToCompare.MaxRoomNumber != 0)
                {
                    if (adToCompare.MaxRoomNumber < ad.RoomNumber) break;
                }

                if (!adToCompare.PoolNoMatter)
                {
                    if (adToCompare.Pool != ad.Pool) break;
                }

                if (!adToCompare.BalkonNoMatter)
                {
                    if (adToCompare.Balkon != ad.Balkon) break;
                }

                if (!adToCompare.PurchaseOportunityNoMatter)
                {
                    if (adToCompare.PurchaseOportunity != ad.PurchaseOportunity) break;
                }
                resutlAds.Add(ad);
            }

            return resutlAds;
        }

        public async Task<IEnumerable<Ad>> GetAdsByUserId(string userId)
        {

                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .Where(ad => ad.OwnerId == userId)
                            .ToListAsync();
            
        }

        public async Task<IEnumerable<Ad>> GetAll()
        {
                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .ToListAsync();
        }

        public async Task<Ad> GetById(int id)
        {
                return await context.Ads.Include(c => c.comments)
                            .Include(i => i.images)
                            .Include(t => t.tags)
                            .Where(ad => ad.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task Update(Ad ad)
        {
                context.Ads.Update(ad);
                await context.SaveChangesAsync();
        }
    }
}
