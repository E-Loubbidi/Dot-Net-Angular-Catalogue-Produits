using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace KafkaService.KafkaStreamProducer
{
    public class KafkaStreamProducer : IHostedService
    {
        private readonly ILogger<KafkaStreamProducer> _logger;
        private readonly IProducer<Null, string> _producer;
        public KafkaStreamProducer(ILogger<KafkaStreamProducer> logger)
        {
            _logger = logger;
            var config =  new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        async Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            for (var i = 0; i < 100; ++i)
            {
                var value = $"Hello World {i}";
                _logger.LogInformation(value);
                await _producer.ProduceAsync("test", new Message<Null, string>()
                {
                    Value = value
                }, cancellationToken);
            }

           var ret = _producer.Flush(TimeSpan.FromSeconds(10));
             Console.WriteLine("Flushing ret=" + ret);
            cancellationToken.ThrowIfCancellationRequested();
             
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}