using Proiect_DAW.Models;
using Proiect_DAW.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public class MasinaDotareRepository : GenericRepository<MasinaDotare>, IMasinaDotareRepository
    {
        public MasinaDotareRepository(Proiect_DAWContext context) : base(context)
        {

        }
    }
}
