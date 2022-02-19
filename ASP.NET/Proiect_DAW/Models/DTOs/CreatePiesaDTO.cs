using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proiect_DAW.Models.DTOs
{
    public class CreatePiesaDTO
    {
        public uint Cost { get; set; }
        public string Tip { get; set; }
        public string Producator { get; set; }
        public int AnFabricatie { get; set; }
        public string Serie { get; set; }
        public string Descriere { get; set; }
    }
}
