using Microsoft.Extensions.Configuration;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;

namespace StatisticMicroservice.Services
{
    public class MqttService
    {
        private IMqttClient Client { get; set; }
        public MqttService(IConfiguration configuration)
        {
            var factory = new MqttFactory();
            Client = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithTcpServer(configuration.GetSection("MqttUrl").Value, 1883).WithCleanSession().Build();

            Client.ConnectAsync(options).Wait();
        }

        public void PublishMessage(string topic, string data)
        {
            if (!Client.IsConnected)
            {
                Console.WriteLine("CLIENT NOT CONNECTED WHILE SENDING MESSAGE");
            }
            else
            {
                Client.PublishAsync(topic, data).Wait();
            }
        }
    }
}
