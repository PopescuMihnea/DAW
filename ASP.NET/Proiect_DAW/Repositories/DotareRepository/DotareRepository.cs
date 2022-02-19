using Proiect_DAW.Models;
using Proiect_DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class DotareRepository : GenericRepository<Dotare>, IDotareRepository
    {
        public DotareRepository(Proiect_DAWContext context) : base(context)
        {

        }
        public async Task<List<Dotare>> GetAllDotari()
        {
            return await _context.Dotari.ToListAsync();
        }
        public async Task<List<Masina>> GetAllMasiniWithDotare(int id)
        {
            return await _context.Dotari.Join(_context.MasinaDotari,d => id, a => a.DotareId, (d,a) => a).Join(_context.Masini,a => a.MasinaId,m=>m.Id, (a,m) => m).ToListAsync();
        }


    }
}