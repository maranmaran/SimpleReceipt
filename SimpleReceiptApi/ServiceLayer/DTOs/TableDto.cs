using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class TableDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long CafeId { get; set; }
        public Cafe Cafe { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
