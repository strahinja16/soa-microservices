using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class BluetoothRepository : IBluetoothRepository
    {
        private readonly AppDbContext _dbContext;

        public BluetoothRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBluetooth(int BluetoothId)
        {
            var product = _dbContext.Blueteeths.Find(BluetoothId);
            _dbContext.Blueteeths.Remove(product);
            Save();
        }

        public Bluetooth GetBluetoothById(int BluetoothId)
        {
            return _dbContext.Blueteeths.Find(BluetoothId);
        }

        public IEnumerable<Bluetooth> GetBluetooths()
        {
            return _dbContext.Blueteeths.ToList();
        }

        public void InsertBluetooth(Bluetooth bluetooth)
        {
            _dbContext.Add(bluetooth);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBluetooth(Bluetooth bluetooth)
        {
            _dbContext.Entry(bluetooth).State = EntityState.Modified;
            Save();
        }
    }
}
