using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class CafeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public long PriceTableId { get; set; }
        public PriceTable PriceTable { get; set; }

        public ICollection<ApplicationUser> Waiters { get; set; }
        public ICollection<Table> Tables { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
