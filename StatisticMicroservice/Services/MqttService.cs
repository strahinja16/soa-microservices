using Microsoft.Extensions.Configuration;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace StatisticMicroservice.Services
{
    public class MqttService
    {
        private IMqttClient Client { get; set; }
        public MqttService(IConfiguration configuration)
        {
            var factory = new MqttFactory();
            Client = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithClientId("Statistics-microservice").WithTcpServer(configuration.GetSection("MqttUrl").Value).Build();
            Client.ConnectAsync(options);
        }

        async public void PublishMessage(string topic, string data)
        {
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
