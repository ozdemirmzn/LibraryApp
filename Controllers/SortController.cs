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
            /*switch (category)
            {
                case 0:
                    books = context.Books
                        .Where(js => js.Category == Category.Art.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 1:
                    books = context.Books
                        .Where(js => js.Category == Category.Biography.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 2:
                    books = context.Books
                        .Where(js => js.Category == Category.Business.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 3:
                    books = context.Books
                        .Where(js => js.Category == Category.Comics.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 4:
                    books = context.Books
                        .Where(js => js.Category == Category.Tech.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 5:
                    books = context.Books
                        .Where(js => js.Category == Category.Cooking.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 6:
                    books = context.Books
                        .Where(js => js.Category == Category.Education.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 7:
                    books = context.Books
                        .Where(js => js.Category == Category.History.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 8:
                    books = context.Books
                        .Where(js => js.Category == Category.Kids.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 9:
                    books = context.Books
                        .Where(js => js.Category == Category.Literature.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 10:
                    books = context.Books
                        .Where(js => js.Category == Category.Medical.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 11:
                    books = context.Books
                        .Where(js => js.Category == Category.ScienceFi.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
                case 12:
                    books = context.Books
                        .Where(js => js.Category == Category.Travel.ToString())
                    .ToList();

                    foreach (var book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
                    break;
            }*/

            books = context.Books
            .Where(js => js.Category == Enum.GetName(typeof(Category), category))
        .ToList();
            foreach (var book in books)
            {
                BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                displayBooks.Add(newDisplayBook);
            }

            ViewBag.books = displayBooks;


            return View("Index");
        }
    }
}
