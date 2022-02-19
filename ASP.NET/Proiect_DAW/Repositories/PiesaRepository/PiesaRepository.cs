using Proiect_DAW.Models;
using Proiect_DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class PiesaRepository : GenericRepository<Piesa>, IPiesaRepository
    {
        public PiesaRepository(Proiect_DAWContext context) : base(context)
        {

        }
        public async Task<List<Piesa>> GetAllPiese()
        {
            return await _context.Piese.ToListAsync();
        }
        public async Task<List<Piesa>> GetByTip(string tip)
        {
            return await _context.Piese.Where(p => p.Tip.ToUpper().Equals(tip.ToUpper())).ToListAsync();
        }
        public async Task<List<Piesa>> GetByProducator(string producator)
        {
            return await _context.Piese.Where(p => p.Producator.ToUpper().Equals(producator.ToUpper())).ToListAsync();
        }
        public async Task<List<Piesa>> GetPieseWithUser()
        {
            return await _context.Piese.Include(p => p.User).ToListAsync();
        }
        public async Task<List<Piesa>> GetPieseCumparate(int id_user)
        {
        return await _context.Piese.Where(p => p.UserId == id_user).ToListAsync();
            
        }

        public async Task<List<Piesa>> GetPieseWithoutUser()
        {
        return await _context.Piese.Where(p => p.UserId == null).ToListAsync();
    }

    }
}
