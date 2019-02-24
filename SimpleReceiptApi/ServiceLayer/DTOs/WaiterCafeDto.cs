using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class WaiterCafeDto
    {
        public long WaiterId { get; set; }
        public ApplicationUser Waiter { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }
    }
}
