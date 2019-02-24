using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class ReceiptPriceTableQueryDto
    {
        public long ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        public long PriceTableQueryId { get; set; }
        public PriceTableQuery PriceTableQuery { get; set; }

        public long Quantity { get; set; }
    }
}
