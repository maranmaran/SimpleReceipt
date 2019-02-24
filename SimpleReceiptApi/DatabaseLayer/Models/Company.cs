using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cafe> Cafes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
