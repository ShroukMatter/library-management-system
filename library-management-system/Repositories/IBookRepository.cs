using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_management_system.Models;

namespace library_management_system.Repositories
{
    // interface for operations on books
    internal interface IBookRepository
    {
        void AddBook(Book book);
        void RemoveBook(string title);
        Book FindBook(string title);
        List<Book> GetAllBooks();
        bool CheckBookAvailability(string title);
        void RentBook(string title);
    }
}
