using LibraryApp.Models;
using LibraryApp.ViewModels;
using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace LibraryApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private BookDbContext context;

        //https://csharp-video-tutorials.blogspot.com/2019/05/file-upload-in-aspnet-core-mvc.html
        //https://www.youtube.com/watch?v=aoxEJii70_I&t=514s
        private readonly IHostingEnvironment hostingEnvironment;

        public BookController(BookDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
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
                string uniqueFileName = null;

                if (addBookViewModel.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + addBookViewModel.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    addBookViewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Book newBook = new Book
                {
                    Name = addBookViewModel.Name,
                    Description = addBookViewModel.Description,
                    ISBN = addBookViewModel.ISBN,
                    Category = addBookViewModel.Category.ToString(),
                    LibraryAddressStreet =addBookViewModel.LibraryAddressStreet,
                    LibraryAddressCity = addBookViewModel.LibraryAddressCity,
                    LibraryAddressState = addBookViewModel.LibraryAddressState,
                    LibraryAddressZip = addBookViewModel.LibraryAddressZip,
                    Latitude = addBookViewModel.Latitude,
                    Longitude = addBookViewModel.Longitude,
                    PhotoPath = uniqueFileName

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
            Book theBook = context.Books.Find(id);
            AddBookViewModel book = new AddBookViewModel
            { 
                Id = theBook.Id,
                Name = theBook.Name,
                Description = theBook.Description,
                ISBN = theBook.ISBN,
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
        public IActionResult ProcessEdit(AddBookViewModel addBookViewModel)
        {
            Book theBook = context.Books.Find(addBookViewModel.Id);

            theBook.Name = addBookViewModel.Name;
            theBook.Description = addBookViewModel.Description;
            theBook.ISBN = addBookViewModel.ISBN;
            theBook.Category = addBookViewModel.Category.ToString();
            theBook.LibraryAddressStreet = addBookViewModel.LibraryAddressStreet;
            theBook.LibraryAddressCity = addBookViewModel.LibraryAddressCity;
            theBook.LibraryAddressState = addBookViewModel.LibraryAddressState;
            theBook.LibraryAddressZip = addBookViewModel.LibraryAddressZip;
            theBook.Longitude = addBookViewModel.Longitude;
            theBook.Latitude = addBookViewModel.Latitude;
                    
            context.Books.Update(theBook);
            context.SaveChanges();

            return Redirect("/book");
        }

    }
}
