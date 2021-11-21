using Entities;
using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly RepositoryContext _context;

        public HouseRepository(RepositoryContext context)
        {
            _context = context;
        }
        public async Task<House> Get(int id, bool trackChanges)
        {
            if (trackChanges)
                return await _context.Houses.SingleOrDefaultAsync(x => x.Id == id);

            return await _context.Houses.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
