using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Movie
    {
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }


        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Date Added")]
        [Required]
        public DateTime DateAdded { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public byte NumberAvailable { get; set; }

    }
}

