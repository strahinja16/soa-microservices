using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class CallContext : DbContext
    {
        public CallContext(DbContextOptions<CallContext> options) : base(options)
        {
        }
        public DbSet<Call> Calls { get; set; }
    }
}
