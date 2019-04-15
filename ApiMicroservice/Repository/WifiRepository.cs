using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class WifiRepository : IWifiRepository
    {
        private readonly AppDbContext _dbContext;

        public WifiRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteWifi(Guid WifiId)
        {
            var product = _dbContext.Wifis.Find(WifiId);
            _dbContext.Wifis.Remove(product);
            Save();
        }

        public Wifi GetWifiById(Guid WifiId)
        {
            return _dbContext.Wifis.Find(WifiId);
        }

        public IEnumerable<Wifi> GetWifis()
        {
            return _dbContext.Wifis.ToList();
        }

        public void InsertWifi(Wifi wifi)
        {
            _dbContext.Add(wifi);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateWifi(Wifi wifi)
        {
            _dbContext.Entry(wifi).State = EntityState.Modified;
            Save();
        }
    }
}
