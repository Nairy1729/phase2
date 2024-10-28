using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip_assign
{

    public class Student : IBorrowable
    {
        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine($"Student borrows the book: {bookTitle}");
        }
    }

    public class Teacher : IBorrowable, IReservable
    {
        public void BorrowBook(string bookTitle)
        {
            Console.WriteLine($"Teacher borrows the book: {bookTitle}");
        }

        public void ReserveBook(string bookTitle)
        {
            Console.WriteLine($"Teacher reserves the book: {bookTitle}");
        }
    }

    public class Librarian : IInventoryManageable
    {
        public void AddBook(string bookTitle)
        {
            Console.WriteLine($"Librarian adds the book: {bookTitle} to inventory");
        }

        public void RemoveBook(string bookTitle)
        {
            Console.WriteLine($"Librarian removes the book: {bookTitle} from inventory");
        }
    }


}
