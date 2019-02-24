using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;

namespace ServiceLayer.Operations
{
    public interface IReceiptOperations
    {
        Task<List<ReceiptDto>> GetAllReceiptsByCafeId(long id);
        void CreateReceipt(ReceiptDto receipt);
        Task<List<ReceiptPriceTableQueryDto>> GetAllReceiptPriceTableQueryByReceiptId(long id);
    }

    internal class ReceiptOperations: IReceiptOperations
    {
        private readonly ApplicationDbContext _context;

        public ReceiptOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReceiptDto>> GetAllReceiptsByCafeId(long id)
        {
            var receipts = await _context.Receipts
                .Include(x => x.Waiter)
                .Include(x => x.Table)
                .Where(x => x.CafeId.Equals(id)).ToListAsync();
            return Mapper.Map<List<ReceiptDto>>(receipts);
        }

        public void CreateReceipt(ReceiptDto receipt)
        {
            var newReceipt = Mapper.Map<Receipt>(receipt);
            newReceipt.ReceiptPriceTableQueries = MergeDuplicateInstances(newReceipt);

            _context.Receipts.Add(newReceipt);
            _context.SaveChanges();
        }

        public async Task<List<ReceiptPriceTableQueryDto>> GetAllReceiptPriceTableQueryByReceiptId(long id)
        {
            var result = await _context.ReceiptPriceTableQueries
                .Include(x => x.PriceTableQuery)
                .ThenInclude(x => x.Product).Where(x => x.ReceiptId.Equals(id)).ToListAsync();

            return Mapper.Map<List<ReceiptPriceTableQueryDto>>(result);
        }

        private List<ReceiptPriceTableQuery> MergeDuplicateInstances(Receipt receipt)
        {
            return receipt.ReceiptPriceTableQueries.GroupBy(o => new { o.PriceTableQueryId, o.ReceiptId})
                .Select(g => new ReceiptPriceTableQuery() { PriceTableQueryId = g.Key.PriceTableQueryId, Quantity = g.Sum(o => o.Quantity), ReceiptId = g.Key.ReceiptId }).ToList();

        }
    }
}
