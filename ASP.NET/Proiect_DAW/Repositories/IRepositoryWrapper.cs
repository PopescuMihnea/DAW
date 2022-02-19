using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IRepositoryWrapper
    {
        IMasinaRepository Masina { get; }
        IDotareRepository Dotare { get; }
        IMasinaDotareRepository MasinaDotare { get; }
        IPiesaRepository Piesa { get; }
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }
        Task SaveAsync();
    }
}
