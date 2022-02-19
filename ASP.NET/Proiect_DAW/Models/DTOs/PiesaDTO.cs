using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.DTOs
{
    public class PiesaDTO
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

        public PiesaDTO(Piesa piesa)
        {
            this.Id = piesa.Id;
            this.Cost = piesa.Cost;
            this.Tip = piesa.Tip;
            this.Producator = piesa.Producator;
            this.AnFabricatie = piesa.AnFabricatie;
            this.Serie = piesa.Serie;
            this.Descriere = piesa.Descriere;
            this.UserId = piesa.UserId;
            this.User = piesa.User;
        }
    }
}
