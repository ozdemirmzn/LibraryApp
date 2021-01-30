using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private BookDbContext context;

        public SearchController(BookDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results(string searchTerm)
        {
            List<Book> books;
            List<BookDetailViewModel> displayBooks = new List<BookDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                books = context.Books
                   .ToList();

                foreach (var book in books)
                {
                    BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                    displayBooks.Add(newDisplayBook);
                }
            }
            else
            {
                    books = context.Books
                        .Where(j => j.Name == searchTerm)
                        .ToList();

                    foreach (Book book in books)
                    {
                        BookDetailViewModel newDisplayBook = new BookDetailViewModel(book);
                        displayBooks.Add(newDisplayBook);
                    }
            }
            ViewBag.books = displayBooks;

            return View("Index");
        }
    }
}
