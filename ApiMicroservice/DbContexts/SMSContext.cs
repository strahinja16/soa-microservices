using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext> options) : base(options)
        {
        }
        public DbSet<SMS> SMSes { get; set; }
    }
}
