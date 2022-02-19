using Proiect_DAW.Models;
using Proiect_DAW.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Proiect_DAWContext _context;
        private IMasinaRepository _masina;
        private IDotareRepository _dotare;
        private IMasinaDotareRepository _masinadotare;
        private IPiesaRepository _piesa;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;

        public RepositoryWrapper(Proiect_DAWContext context)
        {
            _context = context;
        }

        public IMasinaRepository Masina
        {
            get
            {
                if (_masina == null) _masina = new MasinaRepository(_context);
                return _masina;
            }
        }
        public IDotareRepository Dotare
        {
            get
            {
                if (_dotare == null) _dotare = new DotareRepository(_context);
                return _dotare;
            }
        }
        public IMasinaDotareRepository MasinaDotare
        {
            get
            {
                if (_masinadotare == null) _masinadotare = new MasinaDotareRepository(_context);
                return _masinadotare;
            }
        }
        public IPiesaRepository Piesa
        {
            get
            {
                if (_piesa == null) _piesa = new PiesaRepository(_context);
                return _piesa;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
