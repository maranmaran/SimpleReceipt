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

        // for simplicity sake.. one waiter.. one cafe
        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
