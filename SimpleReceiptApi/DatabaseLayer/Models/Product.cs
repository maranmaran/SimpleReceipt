using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DatabaseLayer.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<PriceTableQuery> PriceTableQueries { get; set; }
    }
}
