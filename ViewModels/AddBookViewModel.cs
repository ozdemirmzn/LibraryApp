using LibraryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.ViewModels
{
    public class AddBookViewModel
    {
        public int Id { get; set; }
        public string BarcodeNum { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(20, MinimumLength =4, ErrorMessage ="ISBN needs to be at least 4 characters.")]
        public string ISBN { get; set; }
      
        [Required(ErrorMessage = "Street is required")]
        public string LibraryAddressStreet { get; set; }
      
        [Required(ErrorMessage = "City is required")]
        public string LibraryAddressCity { get; set; }
      
        [Required(ErrorMessage = "State is required")]
        public string LibraryAddressState { get; set; }
     
        [Required(ErrorMessage = "ZipCode is required")]
        public string LibraryAddressZip { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IFormFile Photo { get; set; }
        public Category Category { get; set; }

        

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(Category.Art.ToString(), ((int)Category.Art).ToString()),
            new SelectListItem(Category.Biography.ToString(), ((int)Category.Biography).ToString()),
            new SelectListItem(Category.Business.ToString(), ((int)Category.Business).ToString()),
            new SelectListItem(Category.Comics.ToString(), ((int)Category.Comics).ToString()),
            new SelectListItem(Category.Tech.ToString(), ((int)Category.Tech).ToString()),
            new SelectListItem(Category.Cooking.ToString(), ((int)Category.Cooking).ToString()),
            new SelectListItem(Category.Education.ToString(), ((int)Category.Education).ToString()),
            new SelectListItem(Category.History.ToString(), ((int)Category.History).ToString()),
            new SelectListItem(Category.Kids.ToString(), ((int)Category.Kids).ToString()),
            new SelectListItem(Category.Literature.ToString(), ((int)Category.Literature).ToString()),
            new SelectListItem(Category.Medical.ToString(), ((int)Category.Medical).ToString()),
            new SelectListItem(Category.ScienceFi.ToString(), ((int)Category.ScienceFi).ToString()),
            new SelectListItem(Category.Travel.ToString(), ((int)Category.Travel).ToString()),
        };

        
    }
}
