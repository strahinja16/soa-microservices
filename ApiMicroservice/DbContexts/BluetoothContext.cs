using System;
using Microsoft.EntityFrameworkCore;
using SoaService.Model;

namespace SoaService.DbContexts
{
    public class BluetoothContext : DbContext
    {
        public BluetoothContext(DbContextOptions<BluetoothContext> options) : base(options)
        {
        }
        public DbSet<Bluetooth> Bluetooths { get; set; }
    }
}

