using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DataMicroservice.Services
{
    public class BackgroundService : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly IStorageService storageService;
        private StreamReader streamReader;

        public BackgroundService(IStorageService storageService)
        {
            this.storageService = storageService;
            streamReader = new StreamReader("data/data.txt");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            timer = new Timer(DoWork, null, 0, storageService.Ttl / storageService.GetItemsNumber);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            string line = streamReader.ReadLine();
            if (line != null)
            {
                storageService.addItem(line);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
