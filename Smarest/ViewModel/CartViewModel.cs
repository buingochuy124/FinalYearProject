using Smarest.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Smarest.ViewModel
{
    public class CartViewModel
    {
        public string Id { get; set; }

        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }

        public string UserId { get; set; }
     
        public string TableId { get; set; }
        public double Cost { get; set; }

        public string CategoryName { get; set; }
  
    }
}
