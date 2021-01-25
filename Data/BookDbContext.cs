using LibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryApp.Data
{
    public class BookDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
        

        public BookDbContext(DbContextOptions<BookDbContext> options)
              : base(options)
        {
        }

        
    }
}
