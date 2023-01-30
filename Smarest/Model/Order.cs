using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Order
    {
         public string Id {get;set;}

         [ForeignKey("User")]
         public string UserId {get;set;}
         public User User {get;set;}

         public float Total {get;set;}
         public DateTime Date{ get; set; }

         [NotMapped]
         public List<OrderDetail> OrderDetails { get; set; }
    }
}
