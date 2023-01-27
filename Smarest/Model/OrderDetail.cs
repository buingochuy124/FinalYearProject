using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public int Quantity  { get; set; }

    }
}
