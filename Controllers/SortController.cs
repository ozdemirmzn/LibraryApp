using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [Authorize]
    public class SortController : Controller
    {
        private BookDbContext context;

        public SortController(BookDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sorted(int category)
        {
            List<Book> books = new List<Book>();
            List<BookDetailViewModel> displayBooks = new List<BookDetailViewModel>();
            switch (category)
            {
                case 0:
                    books = context.Books
                        .Where(js => js.Category == Category.Art)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 1:
                    books = context.Books
                        .Where(js => js.Category == Category.Biography)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 2:
                    books = context.Books
                        .Where(js => js.Category == Category.Business)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 3:
                    books = context.Books
                        .Where(js => js.Category == Category.Comics)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 4:
                    books = context.Books
                        .Where(js => js.Category == Category.Tech)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 5:
                    books = context.Books
                        .Where(js => js.Category == Category.Cooking)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 6:
                    books = context.Books
                        .Where(js => js.Category == Category.Education)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 7:
                    books = context.Books
                        .Where(js => js.Category == Category.History)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 8:
                    books = context.Books
                        .Where(js => js.Category == Category.Kids)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 9:
                    books = context.Books
                        .Where(js => js.Category == Category.Literature)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 10:
                    books = context.Books
                        .Where(js => js.Category == Category.Medical)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 11:
                    books = context.Books
                        .Where(js => js.Category == Category.ScienceFi)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 12:
                    books = context.Books
                        .Where(js => js.Category == Category.Travel)
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
            }
            ViewBag.books = displayBooks;


            return View("Index");
        }
    }
}
