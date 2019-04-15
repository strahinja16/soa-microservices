using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class CallRepository : ICallRepository
    {
        private readonly AppDbContext _dbContext;

        public CallRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCall(Guid CallId)
        {
            var product = _dbContext.Calls.Find(CallId);
            _dbContext.Calls.Remove(product);
            Save();
        }

        public Call GetCallById(Guid CallId)
        {
            return _dbContext.Calls.Find(CallId);
        }

        public IEnumerable<Call> GetCalls()
        {
            return _dbContext.Calls.ToList();
        }

        public void InsertCall(Call call)
        {
            _dbContext.Add(call);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCall(Call call)
        {
            _dbContext.Entry(call).State = EntityState.Modified;
            Save();
        }
    }
}
