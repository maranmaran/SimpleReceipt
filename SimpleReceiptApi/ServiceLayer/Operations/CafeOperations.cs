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
    public interface ICafeOperations
    {
        Task<List<CafeDto>> GetAllByUserId(string id);
    }

    internal class CafeOperations: ICafeOperations
    {
        private readonly ApplicationDbContext _context;

        public CafeOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CafeDto>> GetAllByUserId(string id)
        {
            var cafes = await _context.Cafes.Include(x => x.Waiters).Where(x => x.Waiters.Any(y => y.WaiterId.Equals(id))).ToListAsync();
            return Mapper.Map<List<CafeDto>>(cafes);
        }
    }
}
