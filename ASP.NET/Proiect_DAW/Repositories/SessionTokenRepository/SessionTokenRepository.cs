using Proiect_DAW.Models;
using Proiect_DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(Proiect_DAWContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens
                .FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
