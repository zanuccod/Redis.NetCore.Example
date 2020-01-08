using System;

namespace RedisLibrary.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }

        public bool Equal(Book book)
        {
            var result = true;
            result &= Title.Equals(book.Title);
            result &= (Year == book.Year);
            result &= Author.Equals(book.Author);

            return result;
        }

        public override string ToString()
        {
            return $"Id <{Id}> Title <{Title}> Year <{Year}> Author <{Author}>";
        }
    }
}
