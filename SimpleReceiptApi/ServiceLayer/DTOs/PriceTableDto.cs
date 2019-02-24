using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class PriceTableDto
    {
        public long Id { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }

        public ICollection<PriceTableQuery> PriceTableQueries { get; set; }
    }
}
