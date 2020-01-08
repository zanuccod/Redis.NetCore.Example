using System;
using StackExchange.Redis;

namespace RedisLibrary.Redis
{
    public interface IRedisConnection
    {
        ConnectionMultiplexer Connection();
    }
}
