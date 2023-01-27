using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Category
    {
        [Key]
        public int Id{get;set;}
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public List<Item> Items { get; set; }
    }
}
