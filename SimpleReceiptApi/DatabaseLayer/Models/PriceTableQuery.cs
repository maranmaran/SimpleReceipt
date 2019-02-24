using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class PriceTableQuery
    {
        public long Id { get; set; }
        public double Price { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long PriceTableId { get; set; }
        public PriceTable PriceTable { get; set; }

        public ICollection<ReceiptPriceTableQuery> ReceiptPriceTableQueries { get; set; }

    }
}
