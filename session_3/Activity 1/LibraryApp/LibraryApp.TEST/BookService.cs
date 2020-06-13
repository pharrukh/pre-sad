using NUnit.Framework;
using LibraryApp.DAL;
using LibraryApp.BLL;
using System;
using Moq;

namespace LibraryApp.TEST
{
    public class Tests
    {
        Mock<IBookRepository> _bookRepositoryMock;
        [SetUp]
        public void Setup()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookRepositoryMock.Setup(x => x.Create(It.IsAny<Book>()));
        }

        [Test]
        public void Test1()
        {
            var bookService = new BookService(_bookRepositoryMock.Object);
            var book = new Book();
            book.Title = "C# in Depth";
            book.Author = "Jon Skeet";
            bookService.CreateBook(book);
            _bookRepositoryMock.Verify(repo => repo.Create(book));
        }
        [Test]
        public void Test2()
        {
            var bookService = new BookService(_bookRepositoryMock.Object);
            var book = new Book();
            book.Author = "Jon Skeet";
            try
            {
                bookService.CreateBook(book);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "Book Title is missing (Parameter 'book.Title')");
            }
            _bookRepositoryMock.Verify(repo => repo.Create(book), Times.Never());
        }
        [Test]
        public void Test3()
        {
            var bookService = new BookService(_bookRepositoryMock.Object);
            var book = new Book();
            book.Title = "C# in Depth";
            try
            {
                bookService.CreateBook(book);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "Book Author is missing (Parameter 'book.Author')");
            }
            _bookRepositoryMock.Verify(repo => repo.Create(book), Times.Never());
        }
        [Test]
        public void Test4()
        {
            var bookService = new BookService(_bookRepositoryMock.Object);
            try
            {
                bookService.CreateBook(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.Message, "Book is missing (Parameter 'book')");
            }
            _bookRepositoryMock.Verify(repo => repo.Create(null), Times.Never());
        }
    }
}