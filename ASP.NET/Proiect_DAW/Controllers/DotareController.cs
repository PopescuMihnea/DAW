using Proiect_DAW.Models.Constants;
using Proiect_DAW.Repositories;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotareController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public DotareController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllDotari()
        {
            var dotari = await _repository.Dotare.GetAllDotari();

            var dotariToReturn = new List<DotareDTO>();

            foreach (var dotare in dotari)
            {
               dotariToReturn.Add(new DotareDTO(dotare));
            }

            return Ok(dotariToReturn);
        }
        [HttpGet("masini_cu_dotarea/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllMasiniWithDotare(int id)
        {
            var masini = await _repository.Dotare.GetAllMasiniWithDotare(id);

            var masiniToReturn = new List<MasinaDTO>();

            foreach (var masina in masini)
            {
                masiniToReturn.Add(new MasinaDTO(masina));
            }

            return Ok(masiniToReturn);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDotare(CreateDotareDTO dto)
        {
            Dotare newDotare = new Dotare();

            newDotare.Descriere = dto.Descriere;

            _repository.Dotare.Create(newDotare);

            await _repository.SaveAsync();

            return Ok(new DotareDTO(newDotare));
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDotare(int id, UpdateDotareDTO dto)
        {
            Dotare dotare = new Dotare();

            dotare = await _repository.Dotare.GetByIdAsync(id);
            dotare.Descriere = dto.Descriere;

            _repository.Dotare.Update(dotare);

            await _repository.SaveAsync();

            return Ok(new DotareDTO(dotare));
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDotare(int id)
        {
            Dotare dotare = new Dotare();

            dotare = await _repository.Dotare.GetByIdAsync(id);

            _repository.Dotare.Delete(dotare);

            await _repository.SaveAsync();

            return Ok(new DotareDTO(dotare));
        }
        [HttpPost("addDotare/{id_masina:int},{id_dotare:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDotare(int id_masina,int id_dotare)
        {
            MasinaDotare masinadotare = new MasinaDotare();

            masinadotare.DotareId = id_dotare;
            masinadotare.MasinaId = id_masina;

            _repository.MasinaDotare.Create(masinadotare);

            await _repository.SaveAsync();

            return Ok(masinadotare);
        }
    }
}
