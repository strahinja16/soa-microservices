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
            var options = new MqttClientOptionsBuilder().WithClientId("Statistics-microservice").WithTcpServer(configuration.GetSection("MqttUrl").Value, 1883).Build();
            try 
            {
                Client.ConnectAsync(options);
            }
            catch (Exception e)
            {
                Console.WriteLine("MQTT CONNECT EXCEPTION");
                Console.WriteLine(e.Message);
            }
        }

        async public void PublishMessage(string topic, string data)
        {
            if (!Client.IsConnected)
            {
                Console.WriteLine("CLIENT NOT CONNECTED WHILE SENDING MESSAGE");
            }
            else
            {
                Console.WriteLine("PUBLISH MESSAGE");
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(data)
                    //.WithExactlyOnceQoS()
                    //.WithRetainFlag()
                    .Build();

                await Client.PublishAsync(message);
            }
        }
    }
}
