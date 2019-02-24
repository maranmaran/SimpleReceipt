using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.DTOs
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cafe> Cafes { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
