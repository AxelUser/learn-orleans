using System;
using System.Threading.Tasks;
using GrainInterfaces;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var client = await ConnectClientAsync();
            var friend = client.GetGrain<IHello>(0);
            var response = await friend.SayHello("Good luck, have fun!");
            Console.WriteLine(response);
            Console.WriteLine("Press Enter to close...");
            Console.ReadLine();
        }

        private static async Task<IClusterClient> ConnectClientAsync()
        {
            var builder = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "LearnOrleans";
                })
                .ConfigureLogging(logging => logging.AddConsole());

            var client = builder.Build();
            await client.Connect();
            return client;
        }
    }
}