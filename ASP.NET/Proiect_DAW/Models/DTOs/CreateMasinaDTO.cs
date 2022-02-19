using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.DTOs
{
    public class CreateMasinaDTO
    {
        public string Marca { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public string AnFabricare { get; set; }
        public uint Km { get; set; }
        public uint Cost { get; set; }
        public string Descriere { get; set; }
    }
}
