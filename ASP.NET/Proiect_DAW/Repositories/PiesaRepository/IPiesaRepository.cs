using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IPiesaRepository : IGenericRepository<Piesa>
    {
        Task<List<Piesa>> GetAllPiese();
        Task<List<Piesa>> GetByTip(string tip);
        Task<List<Piesa>> GetByProducator(string producator);
        Task<List<Piesa>> GetPieseWithUser();
        Task<List<Piesa>> GetPieseWithoutUser();
        Task<List<Piesa>> GetPieseCumparate(int id_user);
    }
}