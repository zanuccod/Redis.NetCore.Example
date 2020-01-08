using System;
using System.Collections;
using System.Collections.Generic;
using RedisLibrary.Entities;

namespace RedisLibrary.Model
{
    public interface IDataModel<T>
    {
        T Get(string key);

        Dictionary<string, T> GetAll();

        bool Save(string key, T obj);

        bool Delete(string key);
    }
}
