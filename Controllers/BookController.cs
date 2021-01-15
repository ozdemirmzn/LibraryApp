using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private BookDbContext context;

        public BookController(BookDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Book> books = context.Books.ToList();
            return View(books);
        }

        public IActionResult Add()
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel();
            return View(addBookViewModel);
        }

        [HttpPost("/Add")]
        public IActionResult ProcessAddBookForm(AddBookViewModel addBookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book
                {
                    Name = addBookViewModel.Name,
                    Description = addBookViewModel.Description,
                    ISBN = addBookViewModel.ISBN
                };
                context.Books.Add(newBook);
                context.SaveChanges();

                return Redirect("/book");
            }
            return View("Add", addBookViewModel);
        }


        public IActionResult About(int id)
        {
            Book theBook = context.Books
                .Single(e => e.Id == id);

            return View(theBook);
        }




        public IActionResult Delete(int id)
        {
            Book theBook = context.Books
                .Single(e => e.Id == id);

            context.Books.Remove(theBook);
            context.SaveChanges();

            return Redirect("/book");


        }
    }
}
