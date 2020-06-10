using LibraryApp.BLL;
using LibraryApp.DAL;
using System;
using System.Data.SqlClient;

namespace LibraryApp.UI
{
    class Program
    {
        static BookRepository _bookRepo;
        static BookService _bookService;

        static void Main(string[] args)
        {
            _bookRepo = new BookRepository();
            _bookService = new BookService(_bookRepo);

            Console.WriteLine("WELCOME TO LIBRARY APPLICATION. TYPE COMMAND:");

            var shouldWork = true;
            while (shouldWork)
            {
                var input = Console.ReadKey();
                if(input.KeyChar == 'e')
                {
                    Console.Write(" - Exiting...");
                    shouldWork = false;
                }
                else if (input.KeyChar == 'l')
                {
                    Console.Write(" - Preparing list of books... \n");
                    ShowBookList();
                    Console.WriteLine("Done! Type a command");
                }
                else if(input.KeyChar == 'c')
                {
                    Console.Write(" - Type book title:");
                    var book = new Book();
                    book.Title = Console.ReadLine();
                    Console.Write("Type book author:");
                    book.Author = Console.ReadLine();
                    Console.WriteLine("Saving book...");
                    CreateBook(book);
                    Console.WriteLine("Done! Type a command");
                }
                else
                {
                    Console.Write(" - Wrong command... Try again \n");
                }
            }
        }

        private static void CreateBook(Book book)
        {
            try
            {
                _bookService.CreateBook(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex}");
            }
        }

        private static void ShowBookList()
        {
            var books = _bookRepo.GetAll();
            foreach (var book in books)
            {
                Console.WriteLine("ID: {0}, Title: {1}, Author: {2}", 
                                    book.Id,
                                    book.Title,
                                    book.Author
                    );
            }            
        }
    }
}
