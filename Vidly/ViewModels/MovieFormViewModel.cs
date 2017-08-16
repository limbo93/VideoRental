using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GreneType> GreneTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Relese Date")]
        [Required]
        public DateTime? ReleseDate { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }


        [Display(Name = "Grene Type")]
        [Required]
        public byte? GreneTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }

        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleseDate = movie.ReleseDate;
            NumberInStock = movie.NumberInStock;
            GreneTypeId = movie.GreneTypeId;
        }
    }
}