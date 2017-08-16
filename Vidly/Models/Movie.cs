using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        [Display(Name = "Relese Date")]
        public DateTime ReleseDate { get; set; }


        public DateTime DateAdded { get; set; }


        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        [Required]
        public byte NumberInStock { get; set; }


        public GreneType GreneType { get; set; }


        [Display(Name = "Grene Type")]
        public byte GreneTypeId { get; set; }

        public byte NumberAvailable { get; set; }
    }
}