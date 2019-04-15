using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        Application GetApplicationById(Guid ApplicationId);
        void InsertApplication(Application application);
        void DeleteApplication(Guid ApplicationId);
        void UpdateApplication(Application application);
        void Save();
    }
}
