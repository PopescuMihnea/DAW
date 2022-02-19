using Proiect_DAW.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models.DTOs
{
    public class MasinaDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public string Culoare { get; set; }
        public string AnFabricare { get; set; }
        public uint Km { get; set; }
        public uint Cost { get; set; }
        public string Descriere { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public MasinaDTO(Masina masina)
        {
            this.Id = masina.Id;
            this.Marca = masina.Marca;
            this.Model = masina.Model;
            this.Culoare = masina.Culoare;
            this.AnFabricare = masina.AnFabricare;
            this.Km = masina.Km;
            this.Cost = masina.Cost;
            this.Descriere = masina.Descriere;
            this.UserId = masina.UserId;
            this.User = masina.User;
        }
    }
}
