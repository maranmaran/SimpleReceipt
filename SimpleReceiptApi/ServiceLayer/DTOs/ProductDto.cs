using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<PriceTableQuery> PriceTableQueries { get; set; }
    }
}
