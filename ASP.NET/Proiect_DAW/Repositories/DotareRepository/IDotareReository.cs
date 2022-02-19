using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IDotareRepository : IGenericRepository<Dotare>
    {
        Task<List<Dotare>> GetAllDotari();
        Task<List<Masina>> GetAllMasiniWithDotare(int id);
    }
}
