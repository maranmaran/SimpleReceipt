using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class ReceiptPriceTableQuery
    {
        public long ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        public long PriceTableQueryId { get; set; }
        public PriceTableQuery PriceTableQuery { get; set; }

        public long Quantity { get; set; }
    }
}
