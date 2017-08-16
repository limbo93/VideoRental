﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public DateTime ReleseDate { get; set; }


        public DateTime DateAdded { get; set; }


        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }

        public GreneTypeDto GreneType { get; set; }
        public byte GreneTypeId { get; set; }
    }
}