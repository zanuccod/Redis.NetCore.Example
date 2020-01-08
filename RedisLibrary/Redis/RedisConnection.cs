using System;
using StackExchange.Redis;
using Microsoft.Extensions.Options;
using RedisLibrary.Redis;

namespace RedisLibrary.Utils
{
    public class RedisConnection : IRedisConnection
    {
        private readonly Lazy<ConnectionMultiplexer> connection;

        public RedisConnection(IOptions<RedisConfiguration> redis)
        {
            connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(redis.Value.Host));
        }

        public RedisConnection(RedisConfiguration redis)
        {
            connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(redis.Host));
        }

        public ConnectionMultiplexer Connection()
        {
            return connection.Value;
        }
    }
}
