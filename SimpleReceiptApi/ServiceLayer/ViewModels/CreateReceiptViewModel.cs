using System;
using System.Collections.Generic;
using System.Text;
using DatabaseLayer.Models;

namespace ServiceLayer.ViewModels
{
    public class CreateReceiptViewModel
    {
        public long TableId { get; set; }
        public List<ReceiptPriceTableQuery> ReceiptPriceTableQueries { get; set; }
        public string WaiterId { get; set; }
        public double Total { get; set; }
    }
}
