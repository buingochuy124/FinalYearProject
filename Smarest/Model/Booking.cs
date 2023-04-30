using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarest.Model
{
    public class Booking
    {
        public string Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string TableName { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
