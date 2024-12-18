using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) { }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
