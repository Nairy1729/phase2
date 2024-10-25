using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace assign1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var authors = new List<Author>
            {
                new Author { AuthorId = 1, Name = "George Orwell", BirthDate = new DateTime(1903, 6, 25), Nationality = "British" },
                new Author { AuthorId = 2, Name = "J.K. Rowling", BirthDate = new DateTime(1965, 7, 31), Nationality = "British" },
                new Author { AuthorId = 3, Name = "J.R.R. Tolkien", BirthDate = new DateTime(1892, 1, 3), Nationality = "British" },
                new Author { AuthorId = 4, Name = "Mark Twain", BirthDate = new DateTime(1835, 11, 30), Nationality = "American" },
                new Author { AuthorId = 5, Name = "Leo Tolstoy", BirthDate = new DateTime(1828, 9, 9), Nationality = "Russian" }
            };

            var books = new List<Book>
            {
                new Book { BookId = 1, Title = "1984", Genre = "Dystopian", AuthorId = 1, Pages = 328 },
                new Book { BookId = 2, Title = "Harry Potter", Genre = "Fantasy", AuthorId = 2, Pages = 500 },
                new Book { BookId = 3, Title = "The Hobbit", Genre = "Fantasy", AuthorId = 3, Pages = 310 },
                new Book { BookId = 4, Title = "Adventures of Huckleberry Finn", Genre = "Adventure", AuthorId = 4, Pages = 366 },
                new Book { BookId = 5, Title = "War and Peace", Genre = "Historical Fiction", AuthorId = 5, Pages = 1225 }
            };

            string authorsJson = JsonConvert.SerializeObject(authors, Formatting.Indented);
            string booksJson = JsonConvert.SerializeObject(books, Formatting.Indented);

            File.WriteAllText("Authors.json", authorsJson);
            File.WriteAllText("Books.json", booksJson);


            XmlSerializer authorSerializer = new XmlSerializer(typeof(List<Author>));
            using (FileStream fs = new FileStream("Authors.xml", FileMode.Create))
            {
                authorSerializer.Serialize(fs, authors);
            }

            XmlSerializer bookSerializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream("Books.xml", FileMode.Create))
            {
                bookSerializer.Serialize(fs, books);
            }

            Console.WriteLine("Data serialized and saved to disk successfully.");


            var authorsJsonf = JsonConvert.DeserializeObject<List<Author>>(File.ReadAllText("Authors.json"));
            var booksJsonf = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText("Books.json"));

            Console.WriteLine("Authors from JSON:");
            foreach (var author in authorsJsonf)
            {
                Console.WriteLine($"{author.AuthorId}: {author.Name}, Born on {author.BirthDate.ToShortDateString()}, Nationality: {author.Nationality}");
            }

            Console.WriteLine("\nBooks from JSON:");
            foreach (var book in booksJsonf)
            {
                Console.WriteLine($"{book.BookId}: {book.Title}, Genre: {book.Genre}, Pages: {book.Pages}");
            }

            using (FileStream fs = new FileStream("Authors.xml", FileMode.Open))
            {
                XmlSerializer authorSerializerf = new XmlSerializer(typeof(List<Author>));
                var authorsXml = (List<Author>)authorSerializerf.Deserialize(fs);

                Console.WriteLine("\nAuthors from XML:");
                foreach (var author in authorsXml)
                {
                    Console.WriteLine($"{author.AuthorId}: {author.Name}, Born on {author.BirthDate.ToShortDateString()}, Nationality: {author.Nationality}");
                }
            }

            using (FileStream fs = new FileStream("Books.xml", FileMode.Open))
            {
                XmlSerializer bookSerializerf = new XmlSerializer(typeof(List<Book>));
                var booksXml = (List<Book>)bookSerializerf.Deserialize(fs);

                Console.WriteLine("\nBooks from XML:");
                foreach (var book in booksXml)
                {
                    Console.WriteLine($"{book.BookId}: {book.Title}, Genre: {book.Genre}, Pages: {book.Pages}");
                }
            }
            Console.ReadKey();
        }
    }
}

