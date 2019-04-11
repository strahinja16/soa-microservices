using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
    }
}
