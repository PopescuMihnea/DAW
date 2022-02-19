using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.Entities
{
    public class Dotare
    {
        public int Id { get; set; }
        public string Descriere { get; set; }
        public virtual ICollection<MasinaDotare> MasinaDotare { get; set; }
    }
}
