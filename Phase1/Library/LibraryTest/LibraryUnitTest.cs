using LibrarySys;
using System;

namespace LibraryTest
{
    [TestFixture]
    public class LibraryTests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void Test_AddBook()
        {
            var book = new Book("C# Basics", "John Doe", "12345");
            library.AddBook(book);
            Assert.Contains(book, library.Books);
        }

        [Test]
        public void Test_RegisterBorrower()
        {
            var borrower = new Borrower("Alice", "001");
            library.RegisterBorrower(borrower);
            Assert.Contains(borrower, library.Borrowers);
        }

        [Test]
        public void Test_BorrowBook()
        {
            var book = new Book("C# Basics", "John Doe", "12345");
            var borrower = new Borrower("Alice", "001");
            library.AddBook(book);
            library.RegisterBorrower(borrower);

            bool result = library.BorrowBook("12345", "001");
            Assert.IsTrue(result);
            Assert.IsTrue(book.IsBorrowed);
            Assert.Contains(book, borrower.BorrowedBooks);
        }

        [Test]
        public void Test_ReturnBook()
        {
            var book = new Book("C# Basics", "John Doe", "12345");
            var borrower = new Borrower("Alice", "001");
            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("12345", "001");

            bool result = library.ReturnBook("12345", "001");
            Assert.IsTrue(result);
            Assert.IsFalse(book.IsBorrowed);
            Assert.IsEmpty(borrower.BorrowedBooks);
        }

        [Test]
        public void Test_ViewBooksAndBorrowers()
        {
            var book = new Book("C# Basics", "John Doe", "12345");
            var borrower = new Borrower("Alice", "001");
            library.AddBook(book);
            library.RegisterBorrower(borrower);

            Assert.Contains(book, library.ViewBooks());
            Assert.Contains(borrower, library.ViewBorrowers());
        }
    }

}