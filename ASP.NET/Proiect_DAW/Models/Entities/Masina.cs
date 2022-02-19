using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.Entities
{
    public class Masina
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public string AnFabricare { get; set; }
        public uint Km { get; set; }
        public uint Cost { get; set; }
        public int? UserId { get; set; }
        public string Descriere { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MasinaDotare> MasinaDotare { get; set; }
    }
}
