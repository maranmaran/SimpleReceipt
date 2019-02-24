using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class PriceTableQueryDto
    {
        public long Id { get; set; }
        public double Price { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long PriceTableId { get; set; }
        public PriceTable PriceTable { get; set; }

        public ICollection<DatabaseLayer.Models.ReceiptPriceTableQuery> ReceiptPriceTableQueries { get; set; }

    }
}
