using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Receipt
    {
        public long Id { get; set; }
        public double Total { get; set; }
        public DateTime CreatedOn { get; set; }

        public long TableId { get; set; }
        public Table Table { get; set; }

        public string WaiterId { get; set; }
        public ApplicationUser Waiter { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }

        public ICollection<ReceiptPriceTableQuery> ReceiptPriceTableQueries { get; set; }
    }
}
