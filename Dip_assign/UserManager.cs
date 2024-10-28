using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip_assign
{
    public class UserManager
    {
        private readonly IBorrowable _borrowable;
        private readonly IReservable _reservable;
        private readonly IInventoryManageable _inventoryManageable;

        public UserManager(IBorrowable borrowable = null, IReservable reservable = null, IInventoryManageable inventoryManageable = null)
        {
            _borrowable = borrowable;
            _reservable = reservable;
            _inventoryManageable = inventoryManageable;
        }

        public void BorrowBook(string bookTitle)
        {
            _borrowable?.BorrowBook(bookTitle);
        }

        public void ReserveBook(string bookTitle)
        {
            _reservable?.ReserveBook(bookTitle);
        }

        public void AddBook(string bookTitle)
        {
            _inventoryManageable?.AddBook(bookTitle);
        }

        public void RemoveBook(string bookTitle)
        {
            _inventoryManageable?.RemoveBook(bookTitle);
        }
    }
}
