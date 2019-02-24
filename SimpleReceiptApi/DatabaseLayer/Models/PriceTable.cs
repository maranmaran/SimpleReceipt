using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class PriceTable
    {
        public long Id { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }

        public ICollection<PriceTableQuery> PriceTableQueries { get; set; }
    }
}
