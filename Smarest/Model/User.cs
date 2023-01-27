using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smarest.Model
{
    public class User : IdentityUser
    {      
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public List<Order> Orders { get; set; }

        [NotMapped]
        public List<Cart> Carts { get; set; }
    }
}
