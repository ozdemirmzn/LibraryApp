using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class BookDetailViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarcodeNum { get; set; }

        public BookDetailViewModel(Book theBook)
        {
            Name = theBook.Name;
            Description = theBook.Description;
            BarcodeNum = theBook.BarcodeNum;
        }
    }
}
