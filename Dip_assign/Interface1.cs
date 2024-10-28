using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip_assign
{
    public interface IBorrowable
    {
        void BorrowBook(string bookTitle);
    }

    public interface IReservable
    {
        void ReserveBook(string bookTitle);
    }

    public interface IInventoryManageable
    {
        void AddBook(string bookTitle);
        void RemoveBook(string bookTitle);
    }

}
