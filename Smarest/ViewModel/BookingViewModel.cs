using Smarest.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.ViewModel
{
    public class BookingViewModel
    {
       public string Id {get;set;}
       public string TableName {get;set;}
       public DateTime BookingDate = DateTime.Now;
       [ForeignKey("User")]
       public string UserId { get; set; }
       public User User {get;set;}
    }
}
