using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_management_system.Models;

namespace library_management_system.Repositories
{
    // Implementing operations on books
    internal class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();

        // Method to add book 
        public void AddBook(Book book)
        {
            _books.Add(book);
        }


        // Method to remove book 
        public void RemoveBook(string title)
        {
            Book book = FindBook(title);
            if (book != null)
                _books.Remove(book);
            else
                Console.WriteLine("Book doesn't exist");
        }



        // Method to find book 
        public Book FindBook(string title)
        {
            return _books.Find(b => b.Title == title);
        }


        // Method to get all books
        public List<Book> GetAllBooks()
        {
            return _books;
        }


        // Method to check the availablity of a book 
        public bool CheckBookAvailability(string title)
        {
            Book book = FindBook(title);
            return book != null && book.Available;
        }



        // Method to rent a book 

        public void RentBook(string title)
        {
            Book book = FindBook(title);
            if (book != null && book.Available)
            {
                book.Available = false;
                Console.WriteLine("Book rented successfully.");
            }
            else
            {
                Console.WriteLine("Book not available for rent.");
            }
        }
    }

    
}
