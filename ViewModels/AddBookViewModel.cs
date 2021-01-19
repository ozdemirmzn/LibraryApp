using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(20, MinimumLength =4, ErrorMessage ="ISBN needs to be at least 4 characters.")]
        public string ISBN { get; set; }
    }
}
