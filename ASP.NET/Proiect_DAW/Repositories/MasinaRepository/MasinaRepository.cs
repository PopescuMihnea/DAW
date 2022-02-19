using Proiect_DAW.Models;
using Proiect_DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class MasinaRepository: GenericRepository<Masina>, IMasinaRepository
    {
        public MasinaRepository(Proiect_DAWContext context) : base(context)
        {

        }
        public async Task<List<Masina>> GetAllMasini ()
        {
            return await _context.Masini.ToListAsync();
        }
        public async Task<List<Masina>> GetByMarca (string marca)
        {
            return await _context.Masini.Where(m => m.Marca.ToUpper().Equals(marca.ToUpper())).ToListAsync();
        }
        public async Task<List<Dotare>> GetAllDotari(int id)
        {
            return await _context.Masini.Join(_context.MasinaDotari, m => m.Id, a => a.MasinaId, (m, a) => a).Join(_context.Dotari, a => a.DotareId, d => d.Id, (a, d) => d).ToListAsync();
        }
        public async Task<List<Masina>> GetMasiniWithUser()
        {
            return await _context.Masini.Include(m => m.User).ToListAsync();
        }
        public async Task<List<Masina>> GetMasiniWithoutUser()
        {
            return await _context.Masini.Where(m => m.UserId == null).ToListAsync();
        }

        public async Task<List<Masina>> GetMasinaRezervata(int id_user)
        {
            return await _context.Masini.Where(m => m.UserId == id_user).ToListAsync();
        }

    }
}
