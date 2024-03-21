using System.Collections.Generic;
using library_management_system.Models;
using library_management_system.Repositories;
namespace library_management_system
{

    internal class Program
    {
        private static readonly IBookRepository _bookRepository = new BookRepository();


        static void Main(string[] args)
        {
            // displaying menu and handling user input
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Library Management System\n");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Remove a Book");
                Console.WriteLine("3. Find a Book");
                Console.WriteLine("4. Rent a Book");
                Console.WriteLine("5. Show Books");
                Console.WriteLine("6. Check Book availability");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        FindBook();
                        break;
                    case "4":
                        RentBook();
                        break;
                    case "5":
                        ShowBooks();
                        break;
                    case "6":
                        CheckBookAvailability();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static void AddBook()
        {
            Console.WriteLine("\nEnter book details:");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            if (CheckEmpty(title))
            {
                Console.WriteLine("Enter valid Data");
                return;
            }
            Console.Write("Author: ");
            string author = Console.ReadLine();
            if (CheckEmpty(author))
            {
                Console.WriteLine("Enter valid Data");
                return;
            }
            Console.Write("Genre: ");
            string genre = Console.ReadLine();
            if (CheckEmpty(genre))
            {
                Console.WriteLine("Enter valid Data");
                return;
            }
            Console.Write("Publication Year: ");
            int publicationYear;

            //check if the user input is valid year 
            while (!int.TryParse(Console.ReadLine(), out publicationYear) || publicationYear <= 0 || publicationYear > 2030)
            {
                Console.WriteLine("Invalid publication year. Please enter a valid year.");
                Console.Write("Publication Year: ");
            }
          

            Book book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = publicationYear,
                Available = true
            };

            _bookRepository.AddBook(book);

            Console.WriteLine("Book added successfully.");
        }

        private static void RemoveBook()
        {
            Console.Write("\nEnter the title of the book to remove: ");
            string title = Console.ReadLine();

            _bookRepository.RemoveBook(title);

            Console.WriteLine("Book removed successfully.");
        }

        private static void FindBook()
        {
            Console.Write("\nEnter the title of the book to find: ");
            string title = Console.ReadLine();

            Book book = _bookRepository.FindBook(title);
            if (book != null)
            {
                Console.WriteLine("\nBook details:");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Publication Year: {book.PublicationYear}");
                Console.WriteLine($"Availability: {(book.Available ? "Available" : "Not Available")}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private static void RentBook()
        {
            Console.Write("\nEnter the title of the book to rent: ");
            string title = Console.ReadLine();

            _bookRepository.RentBook(title);
        }

        private static void ShowBooks()
        {
            Console.WriteLine("\nAll Books:");
            List<Book> books = _bookRepository.GetAllBooks();   
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Availability: {(book.Available ? "Available" : "Not Available")}");
            }
        }

        private static void CheckBookAvailability()
        {
            Console.Write("\nEnter the title of the book to check availability: ");
            string title = Console.ReadLine();

            bool available = _bookRepository.CheckBookAvailability(title);
            if (available)
                Console.WriteLine("Book is available.");
            else
                Console.WriteLine("Book is not available.");
        }


        //check if the user input is empty 
        private static bool CheckEmpty(string txt)
        {
            return string.IsNullOrEmpty(txt.Trim());
                
        }
    }
}