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
        Task<List<CafeDto>> GetAllByCompanyId(long id);
    }

    internal class CafeOperations: ICafeOperations
    {
        private readonly ApplicationDbContext _context;

        public CafeOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CafeDto>> GetAllByCompanyId(long id)
        {
            var cafes = await _context.Cafes.Where(x => x.CompanyId.Equals(id)).ToListAsync();
            return Mapper.Map<List<CafeDto>>(cafes);
        }
    }
}
