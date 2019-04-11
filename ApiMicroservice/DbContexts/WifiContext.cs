using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class WifiContext : DbContext
    {
        public WifiContext(DbContextOptions<WifiContext> options) : base(options)
        {
        }
        public DbSet<Wifi> Wifis { get; set; }
    }
}
