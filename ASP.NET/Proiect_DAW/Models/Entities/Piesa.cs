using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.Entities
{
    public class Piesa
    {
        public int Id { get; set; }
        public uint Cost { get; set; }
        public string Tip { get; set; }
        public string Producator { get; set; }
        public int AnFabricatie { get; set; }
        public string Serie { get; set; }
        public string Descriere { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
