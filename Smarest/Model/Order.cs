using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id {get;set;}

         [ForeignKey("User")]
         public string UserId {get;set;}
         public User User {get;set;}

         [NotMapped]
         public string UserName { get;set;}

         public double Total {get;set;}
         public DateTime Date{ get; set; }

         [NotMapped]
         public List<OrderDetail> OrderDetails { get; set; }
    }
}
