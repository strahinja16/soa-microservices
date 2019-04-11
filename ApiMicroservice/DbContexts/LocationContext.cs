using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options) : base(options)
        {
        }
        public DbSet<Location> Locations { get; set; }
    }
}
