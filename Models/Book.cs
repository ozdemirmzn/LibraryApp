﻿using System;
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

        public int ISBN { get; set; }

        public Book()
        {
        }

        public Book(string name, string description, int isbn)
        {
            Name = name;
            Description = description;
            ISBN = isbn;
            
        }
    }
}
