using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public double Cost {get;set;}
        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }


        [NotMapped]
        public List<OrderDetail> OrderDetail { get; set; }
        [NotMapped]
        public List<Cart> Carts { get; set; }
        [NotMapped]
        public Category Categories { get; set; }
    } 
}
