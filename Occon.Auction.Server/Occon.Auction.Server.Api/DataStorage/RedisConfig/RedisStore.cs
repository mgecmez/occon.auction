using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Auction.Server.Api.DataStorage.RedisConfig
{
    public class RedisStore
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static RedisStore()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { { "localhost", 6379 } }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisDb => Connection.GetDatabase();
    }
}
