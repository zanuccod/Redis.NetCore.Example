using System;
using RedisLibrary.Entities;
using RedisLibrary.Redis;
using RedisLibrary.Services;
using RedisLibrary.Utils;

namespace RedisLibrary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new RedisConfiguration()
            {
                Host = "127.0.0.1",
                Port = 5000,
                Name = "localhost"
            };
            var connection = new RedisConnection(conf);

            var service = new RedisJsonBookService(connection);

            var item = new Book()
            {
                Author = "Author test",
                Title = "Title test",
                Year = 1970
            };

            service.InsertBook(item);
            Console.WriteLine($"Item with key {item.Id} saved. Collection size: {service.GetAllBooks().Count}");

            var readItem = service.GetBook(item.Id);

            Console.WriteLine($"Item with key {item.Id} readed: {readItem?.ToString()}");

            var deleted = service.DeleteBook(item.Id);

            Console.WriteLine($"Item with key {item.Id} deleted: {deleted}. Collection size: {service.GetAllBooks().Count}");
        }
    }
}
