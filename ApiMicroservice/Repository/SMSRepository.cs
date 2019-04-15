using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class SMSRepository : ISMSRepository
    {
        private readonly AppDbContext _dbContext;

        public SMSRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteSMS(Guid SMSId)
        {
            var product = _dbContext.SMSes.Find(SMSId);
            _dbContext.SMSes.Remove(product);
            Save();
        }

        public SMS GetSMSById(Guid SMSId)
        {
            return _dbContext.SMSes.Find(SMSId);
        }

        public IEnumerable<SMS> GetSMSes()
        {
            return _dbContext.SMSes.ToList();
        }

        public void InsertSMS(SMS sms)
        {
            _dbContext.Add(sms);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateSMS(SMS sms)
        {
            _dbContext.Entry(sms).State = EntityState.Modified;
            Save();
        }
    }
}
