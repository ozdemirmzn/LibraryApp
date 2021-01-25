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
        


        public Category Category { get; set; }
        

        public Book()
        {
            BarcodeNum = GenerateBarcodeNum();     
        }

        public Book(string name, string description, string isbn) : this()
        {
            Name = name;
            Description = description;
            ISBN = isbn;
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
