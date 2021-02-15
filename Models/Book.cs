using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public class Book
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string ISBN { get; set; }

        public string BarcodeNum { get; set; }

        public string LibraryAddressStreet { get; set; }
        public string LibraryAddressCity { get; set; }
        public string LibraryAddressState { get; set; }
        public string LibraryAddressZip { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        private const double homeLatitude = 39.0997;

        private const double homeLongitude = -94.5786;
        public double HomeLatitude { get { return homeLatitude; } }
        public double HomeLongitude { get { return homeLongitude; } }

        public string PhotoPath { get; set; }



        public string Category { get; set; }
        

        public Book()
        {
            BarcodeNum = GenerateBarcodeNum();     
        }

        public Book(string name, string description, string isbn, string address, string city, string state, string zip) : this()
        {
            Name = name;
            Description = description;
            ISBN = isbn;
            LibraryAddressStreet = address;
            LibraryAddressCity = city;
            LibraryAddressState = state;
            LibraryAddressZip = zip;
        }

        
        private String GenerateBarcodeNum()
        {
            string generateBarcodeNum = "9";
            Random rnd = new Random();
            int randomNum = rnd.Next(10000000, 90000000);
            return generateBarcodeNum + randomNum;
        }

    }

    
}
