using System.Linq;
using RedisLibrary.Redis;
using StackExchange.Redis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RedisLibrary.Model
{
    public class RedisJsonDataModel<T> : IDataModel<T>
    {
        private readonly IDatabase Db;
        private readonly IRedisConnection Connection;

        public RedisJsonDataModel(IRedisConnection connection)
        {
            Connection = connection;
            Db = Connection.Connection().GetDatabase();
        }

        public T Get(string key)
        {
            try
            {
                var value = Db.StringGet(key);
                if (!value.IsNull)
                    return JsonConvert.DeserializeObject<T>(value);
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// ONLY FOR DEBUG.
        /// server.Keys() may ruin performance when it is executed against large databases.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, T> GetAll()
        {
            var endpoints = Connection.Connection().GetEndPoints();
            var server = Connection.Connection().GetServer(endpoints.First());
            var items = new Dictionary<string, T>();

            foreach(var key in server.Keys())
                items.Add(key, Get(key));

            return items;
        }

        public bool Save(string key, T item)
        {
            return Db.StringSet(key, JsonConvert.SerializeObject(item));
        }

        public bool Delete(string key)
        {
            return Db.KeyDelete(key);
        }
    }
}
