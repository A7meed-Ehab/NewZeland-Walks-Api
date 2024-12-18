using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;

        public SQLRegionRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
             await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid Id)
        {
            var model =await _context.Regions.FindAsync(Id);
            if (model == null)
            {
                return null;
            }
            _context.Regions.Remove(model);
            await  _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Region>> GetAllAsync()
        {
          return  await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
         return await _context.Regions.AsNoTracking().Where(r=>r.Id==id).FirstAsync();
        }

        public async Task<Region?> UpdateAsync(Guid Id, Region region)
        {
            var searchRegion = await _context.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if (searchRegion == null)
            {
                return null; // Entity not found
            }
            if (region == null)
            {
                return null;
            }
            searchRegion.Code = region.Code;
            searchRegion.Name = region.Name;
            searchRegion.RegionImageUrl = region.RegionImageUrl;
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
