﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smarest.Model
{
    public class Category
    {
        [Key]
        public int Id{get;set;}
        [Required]
        public string Name { get; set; }

        public List<Item> Items { get; set; }
    }
}
