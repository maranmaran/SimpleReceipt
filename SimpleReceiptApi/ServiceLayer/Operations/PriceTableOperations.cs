using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;

namespace ServiceLayer.Operations
{
    public interface IPriceTableOperations
    {
        Task<List<PriceTableQueryDto>> GetAllPriceTableQueriesByCafeId(long id);
    }

    internal class PriceTableOperations: IPriceTableOperations
    {
        private readonly ApplicationDbContext _context;

        public PriceTableOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PriceTableQueryDto>> GetAllPriceTableQueriesByCafeId(long id)
        {
            var priceTableQueries = _context.PriceTableQueries
                .Include(x => x.PriceTable)
                .Where(x => x.PriceTable.CafeId.Equals(id)).ToListAsync();

            return Mapper.Map<List<PriceTableQueryDto>>(priceTableQueries);
        }
    }
}
