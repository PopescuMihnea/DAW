using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.DTOs
{
    public class DotareDTO
    {
        public int Id { get; set; }
        public string Descriere { get; set; }

        public DotareDTO(Dotare dotare)
        {
            this.Id = dotare.Id;
            this.Descriere = dotare.Descriere;
        }
    }
}
