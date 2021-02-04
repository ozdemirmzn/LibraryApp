using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookDbContext context;

        public BookController(BookDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
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
                    ISBN = addBookViewModel.ISBN,
                    Category = addBookViewModel.Category.ToString(),
                    LibraryAddressStreet =addBookViewModel.LibraryAddressStreet,
                    LibraryAddressCity = addBookViewModel.LibraryAddressCity,
                    LibraryAddressState = addBookViewModel.LibraryAddressState,
                    LibraryAddressZip = addBookViewModel.LibraryAddressZip
                    
                };

               // newBook.BarcodeNum = newBook.BarcodeNum;
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
        
        public IActionResult Edit(int id)
        {
            Book theBook = context.Books
                .Single(e => e.Id == id);
            AddBookViewModel book = new AddBookViewModel 
            {
                Name = theBook.Name,
                Description = theBook.Description,
                ISBN = theBook.ISBN,
                BarcodeNum = theBook.BarcodeNum,
                //converts string to enum
                Category = (Category)Enum.Parse(typeof(Category), theBook.Category, true),
                LibraryAddressStreet = theBook.LibraryAddressStreet,
                LibraryAddressCity = theBook.LibraryAddressCity,
                LibraryAddressState = theBook.LibraryAddressState,
                LibraryAddressZip = theBook.LibraryAddressZip
            };
            
            return View(book);
        }

        [HttpPost("/Edit")]
        public IActionResult ProcessEdit(AddBookViewModel book)
        {
            Book updatedBook = new Book
            {
                Id = book.Id,
                BarcodeNum = book.BarcodeNum,
                Name = book.Name,
                Description = book.Description,
                ISBN = book.ISBN,
                Category = book.Category.ToString(),
                LibraryAddressStreet = book.LibraryAddressStreet,
                LibraryAddressCity = book.LibraryAddressCity,
                LibraryAddressState = book.LibraryAddressState,
                LibraryAddressZip = book.LibraryAddressZip
            };
            context.Books.Update(updatedBook);
            context.SaveChanges();

            return Redirect("/book");
        }

    }
}
