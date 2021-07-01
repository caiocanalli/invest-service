using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Invest.Infra.Cache
{
    public abstract class BaseCacheService
    {
        protected readonly IDatabase Db;
        protected const string RootNamespace = "Invest";
        protected readonly ILogger<BaseCacheService> Logger;

        protected BaseCacheService(
            IConfiguration configuration,
            ILogger<BaseCacheService> logger)
        {
            Logger = logger;

            try
            {
                var connection = ConnectionMultiplexer.Connect(configuration["Cache"]);
                Db = connection.GetDatabase();
            }
            catch (Exception e)
            {
                Logger.LogError("Redis connection error");
            }
        }
    }
}