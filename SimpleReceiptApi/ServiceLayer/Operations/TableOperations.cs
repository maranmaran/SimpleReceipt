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
    public interface ITableOperations
    {
        Task<List<TableDto>> GetAllByCafeId(long id);
    }

    internal class TableOperations: ITableOperations
    {
        private readonly ApplicationDbContext _context;

        public TableOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TableDto>> GetAllByCafeId(long id)
        {
            var tables = await _context.Tables.Where(x => x.CafeId.Equals(id)).ToListAsync();
            return Mapper.Map<List<TableDto>>(tables);
        }
    }
}
