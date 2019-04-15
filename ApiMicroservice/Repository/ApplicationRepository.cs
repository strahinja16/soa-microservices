using Microsoft.EntityFrameworkCore;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMicroservice.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _dbContext;

        public ApplicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteApplication(Guid ApplicationId)
        {
            var product = _dbContext.Applications.Find(ApplicationId);
            _dbContext.Applications.Remove(product);
            Save();
        }

        public Application GetApplicationById(Guid ApplicationId)
        {
            return _dbContext.Applications.Find(ApplicationId);
        }

        public IEnumerable<Application> GetApplications()
        {
            return _dbContext.Applications.ToList();
        }

        public void InsertApplication(Application application)
        {
            _dbContext.Add(application);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateApplication(Application application)
        {
            _dbContext.Entry(application).State = EntityState.Modified;
            Save();
        }
    }
}
