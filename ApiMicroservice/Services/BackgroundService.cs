﻿using System.Threading;
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
using ApiMicroservice.Services.DataService;
using ApiMicroservice.Repository;
using ApiMicroservice.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMicroservice.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private BackgroundTimer backgroundTimer;

        public BackgroundService(IConfiguration configuration, IHttpClientFactory clientFactory, IServiceProvider serviceProvider, BackgroundTimer backgroundTimer)
        {
            this.configuration = configuration;
            this.clientFactory = clientFactory;
            this.serviceProvider = serviceProvider;
            this.backgroundTimer = backgroundTimer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            backgroundTimer.setCallback(DoWork);

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            string baseUrl = configuration.GetValue<string>("DataHostBaseUrl");
            var request = new HttpRequestMessage(HttpMethod.Get,
            baseUrl + "/api/data");

            var client = clientFactory.CreateClient();

            var response =  await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<IEnumerable<JObject>>();

                using (var scope = serviceProvider.CreateScope())
                {
                    foreach (JObject obj in data)
                    {
                        string type = obj.Properties().ElementAt(0).Name;
                        IDataService dataService = null;

                        switch (type)
                        {
                            case "Application":
                                dataService = scope.ServiceProvider.GetService<ApplicationDataService>();
                                break;
                            case "Bluetooth":
                                dataService = scope.ServiceProvider.GetService<BluetoothDataService>();
                                break;
                            case "Call":
                                dataService = scope.ServiceProvider.GetService<CallDataService>();
                                break;
                            case "Location":
                                dataService = scope.ServiceProvider.GetService<LocationDataService>();
                                break;
                            case "SMS":
                                dataService = scope.ServiceProvider.GetService<SMSDataService>();
                                break;
                            case "WiFi":
                                dataService = scope.ServiceProvider.GetService<WiFiDataService>();
                                break;
                        }

                        if (dataService != null)
                        {
                            dataService.Save(obj);
                        }
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            backgroundTimer.stopTimer();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            backgroundTimer.Dispose();
        }
    }
}
