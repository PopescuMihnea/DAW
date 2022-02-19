using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IMasinaRepository : IGenericRepository <Masina>
    {
        Task<List<Masina>> GetAllMasini();
        Task<List<Masina>> GetByMarca(string marca);
        Task<List<Dotare>> GetAllDotari(int id);
        Task<List<Masina>> GetMasiniWithUser();
        Task<List<Masina>> GetMasiniWithoutUser();
        Task<List<Masina>> GetMasinaRezervata(int id_user);
    }
}
