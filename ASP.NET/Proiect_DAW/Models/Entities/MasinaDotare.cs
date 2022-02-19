using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.Entities
{
    public class MasinaDotare
    {
        public int MasinaId { get; set; }
        public virtual Masina Masina { get; set; }
        public int DotareId { get; set; }
        public virtual Dotare Dotare { get; set; }
    }
}
