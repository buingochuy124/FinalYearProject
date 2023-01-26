using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Item
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public float Cost {get;set;}
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
