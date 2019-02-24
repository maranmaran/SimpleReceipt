using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Operations
{
    public interface IApplicationUserOperations
    {
        Task<List<ApplicationUser>> GetAllWaitersByCafeId(long id);
    }

    internal class ApplicationUserOperations : IApplicationUserOperations
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllWaitersByCafeId(long id)
        {
            var waiters = await _context.ApplicationUsers.Include(x => x.Cafes).Where(x => x.Cafes.Any(y => y.CafeId.Equals(id))).ToListAsync();

            return waiters;
        }
    }
}
