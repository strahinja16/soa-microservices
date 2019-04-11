using Microsoft.EntityFrameworkCore;
using ApiMicroservice.Model;

namespace ApiMicroservice.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Bluetooth> Blueteeths { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SMS> SMSes { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
    }
}
