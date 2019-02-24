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
            var receipts = await _context.Receipts.Where(x => x.CafeId.Equals(id)).ToListAsync();
            return Mapper.Map<List<ReceiptDto>>(receipts);
        }
    }
}
