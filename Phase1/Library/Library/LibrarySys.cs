using System;

namespace LibrarySys
{
    /// <summary>
    /// Represents a book in the library system.
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false;
        }

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }

    /// <summary>
    /// Represents a borrower in the library system.
    /// </summary>
    public class Borrower
    {
        public string Name { get; set; }
        public string LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        public Borrower(string name, string cardNumber)
        {
            Name = name;
            LibraryCardNumber = cardNumber;
        }

        public void BorrowBook(Book book)
        {
            if (!book.IsBorrowed)
            {
                book.Borrow();
                BorrowedBooks.Add(book);
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.Return();
                BorrowedBooks.Remove(book);
            }
        }
    }

    /// <summary>
    /// Represents the library, managing books and borrowers.
    /// </summary>
    public class Library
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<Borrower> Borrowers { get; private set; } = new List<Borrower>();

        public void AddBook(Book book) => Books.Add(book);
        public void RegisterBorrower(Borrower borrower) => Borrowers.Add(borrower);

        public bool BorrowBook(string isbn, string libraryCardNumber)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsBorrowed);
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

            if (book != null && borrower != null)
            {
                borrower.BorrowBook(book);
                return true;
            }
            return false;
        }

        public bool ReturnBook(string isbn, string libraryCardNumber)
        {
            var borrower = Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);
            var book = borrower?.BorrowedBooks.FirstOrDefault(b => b.ISBN == isbn);

            if (book != null)
            {
                borrower.ReturnBook(book);
                return true;
            }
            return false;
        }

        public List<Book> ViewBooks() => Books;
        public List<Borrower> ViewBorrowers() => Borrowers;
    }

    /// <summary>
    /// Main entry point of the Library Management System.
    /// </summary>
    class Program
    {
        static void Main()
        {
            Library library = new Library();

            // Adding Books
            library.AddBook(new Book("C# Basics", "John Doe", "12345"));
            library.AddBook(new Book("Java Essentials", "Jane Doe", "67890"));

            // Registering Borrowers
            library.RegisterBorrower(new Borrower("Alice", "001"));
            library.RegisterBorrower(new Borrower("Bob", "002"));

            // Borrowing a Book
            library.BorrowBook("12345", "001");

            // Returning a Book
            library.ReturnBook("12345", "001");

            // Viewing Books
            Console.WriteLine("Books in Library:");
            foreach (var book in library.ViewBooks())
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Borrowed: {book.IsBorrowed}");
            }

            // Viewing Borrowers
            Console.WriteLine("\nBorrowers in Library:");
            foreach (var borrower in library.ViewBorrowers())
            {
                Console.WriteLine($"Name: {borrower.Name}, Card Number: {borrower.LibraryCardNumber}");
            }
        }
    }
}