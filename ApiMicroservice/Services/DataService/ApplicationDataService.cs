using ApiMicroservice.Model;
using ApiMicroservice.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMicroservice.Services.DataService
{
    public class ApplicationDataService: IDataService
    {
        private IApplicationRepository applicationRepository;

        public ApplicationDataService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }
        public void Save(JObject obj)
        {
            string type = obj.Properties().ElementAt(0).Name;
            JObject data = (JObject)obj[type];

            Application app = data.ToObject<Application>();

            Application application = applicationRepository.GetApplicationById(app.Id);

            if(application == null)
            {
                applicationRepository.InsertApplication(app);
            }
        }
    }
}
