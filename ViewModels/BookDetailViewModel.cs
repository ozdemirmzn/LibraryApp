using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarcodeNum { get; set; }
        public string LibraryAddressStreet { get; set; }
        public string LibraryAddressCity { get; set; }
        public string LibraryAddressState { get; set; }
        public string LibraryAddressZip { get; set; }
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        

        

        public BookDetailViewModel(Book theBook)
        {
            Id = theBook.Id;
            Name = theBook.Name;
            Description = theBook.Description;
            BarcodeNum = theBook.BarcodeNum;
            LibraryAddressStreet = theBook.LibraryAddressStreet;
            LibraryAddressCity = theBook.LibraryAddressCity;
            LibraryAddressState = theBook.LibraryAddressState;
            LibraryAddressZip = theBook.LibraryAddressZip;
            Latitude = theBook.Latitude;
            Longitude = theBook.Longitude;
            
        }
    }
}
