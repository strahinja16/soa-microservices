using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using StatisticMicroservice.Services;
using StatisticMicroservice.Repository;
using StatisticMicroservice.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private readonly BackgroundTimer[] backgroundTimers;

        public BackgroundService(IConfiguration configuration, IHttpClientFactory clientFactory, IServiceProvider serviceProvider, BackgroundTimer backgroundTimer)
        {
            this.configuration = configuration;
            this.clientFactory = clientFactory;
            this.serviceProvider = serviceProvider;
            this.backgroundTimers = new BackgroundTimer[3];
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TimerCallback[] callbacks = new TimerCallback[3];
            callbacks[0] = DoWifiWork;
            callbacks[1] = DoLocationWork;
            callbacks[2] = DoSMSWork;

            for (int i = 0; i < callbacks.Length; ++i) {
                backgroundTimers[i] = new BackgroundTimer();
                backgroundTimers[i].SetCallback(callbacks[i]);
            }

            return Task.CompletedTask;
        }

        private enum ServiceEndpoints
        {
            SMS,
            Wifi,
            Location,
        }

        private async void DoWork(string endpoint) 
        {
            string baseUrl = configuration.GetValue<string>("ApiHostBaseUrl");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/api/{endpoint}");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<IEnumerable<JObject>>();

                using (var scope = serviceProvider.CreateScope())
                {
                    Console.WriteLine($"Service {endpoint} {data}");

                    IDataService service = null;

                    switch (endpoint)
                    {
                        case "Location":
                            service = scope.ServiceProvider.GetService<LocationAccuracyService>();
                            break;
                        case "SMS":
                            service = scope.ServiceProvider.GetService<AddressCountService>();
                            break;
                        case "Wifi":
                            service = scope.ServiceProvider.GetService<WifiCapabilityService>();
                            break;
                    }
                    
                    if (service != null) {
                        service.DoWork(data);
                    }
                }
            }
        }

        private void DoSMSWork(object state)
        {
            this.DoWork(Enum.GetName(typeof(ServiceEndpoints), 0));
        }


        private void DoWifiWork(object state) 
        {
            this.DoWork(Enum.GetName(typeof(ServiceEndpoints), 1));
        }

        private void DoLocationWork(object state)
        {
            this.DoWork(Enum.GetName(typeof(ServiceEndpoints), 2));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            foreach(var timer in backgroundTimers) {
                timer.StopTimer();
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            foreach(var timer in backgroundTimers) {
                timer.Dispose();
            }
        }
    }
}
