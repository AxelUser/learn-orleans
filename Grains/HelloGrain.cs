using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains
{
    public class HelloGrain: Orleans.Grain, IHello
    {
        private readonly ILogger<HelloGrain> _logger;

        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }

        public Task<string> SayHello(string greeting)
        {
            _logger.LogInformation($"[SayHello] Message received: {greeting}");
            return Task.FromResult($"You said '{greeting}', so I say hello!");
        }
    }
}