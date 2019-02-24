using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;

namespace ServiceLayer.Operations
{
    public interface IPriceTableQueryOperations
    {
        Task<List<PriceTableQueryDto>> GetAllPriceTableQueriesByCafeId(long id);

    }

    internal class PriceTableQueryOperations: IPriceTableQueryOperations
    {
        private readonly ApplicationDbContext _context;

        public PriceTableQueryOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PriceTableQueryDto>> GetAllPriceTableQueriesByCafeId(long id)
        {
            var priceTableQueries = await _context.PriceTableQueries
                .Include(x => x.PriceTable)
                .Include(x => x.Product)
                .Where(x => x.PriceTable.CafeId.Equals(id)).AsNoTracking().ToListAsync();

            return Mapper.Map<List<PriceTableQueryDto>>(priceTableQueries);
        }
    }
}
