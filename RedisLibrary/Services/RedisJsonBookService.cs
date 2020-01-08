using System;
using System.Collections.Generic;
using System.Linq;
using RedisLibrary.Entities;
using RedisLibrary.Model;
using RedisLibrary.Redis;

namespace RedisLibrary.Services
{
    public class RedisJsonBookService
    {
        private readonly RedisJsonDataModel<Book> model;

        public RedisJsonBookService(IRedisConnection connection)
        {
            model = new RedisJsonDataModel<Book>(connection);
        }

        #region Public Methods

        public Book GetBook(string key)
        {
            return model.Get(key);
        }

        public List<Book> GetAllBooks()
        {
            return model.GetAll().Values.ToList();
        }

        public bool InsertBook(Book item)
        {
            item.Id = GenerateKey(item);
            return model.Save(item.Id, item);
        }

        public bool DeleteBook(string key)
        {
            return model.Delete(key);
        }

        private string GenerateKey(Book item)
        {
            // accordind to Redis guidelines type:key
            return string.Format("{0}:{1}", item.GetType().Name, Guid.NewGuid().ToString());
        }

        #endregion
    }
}
