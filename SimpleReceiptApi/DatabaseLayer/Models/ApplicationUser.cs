using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DatabaseLayer.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<WaiterCafe> Cafes { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
