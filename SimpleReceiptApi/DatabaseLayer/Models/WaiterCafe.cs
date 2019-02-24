using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class WaiterCafe
    {
        public string WaiterId { get; set; }
        public ApplicationUser Waiter { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }
    }
}
