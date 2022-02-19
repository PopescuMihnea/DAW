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
    public class MasinaController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public MasinaController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllMasini()
        {
            var masini =await _repository.Masina.GetAllMasini();

            var masiniToReturn = new List<MasinaDTO>();

            foreach (var masina in masini)
            {
                masiniToReturn.Add(new MasinaDTO(masina));
            }

            return Ok(masiniToReturn);
        }
        [HttpGet("cu_marca/{marca}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetByMarca(string marca)
        {
            var masini = await _repository.Masina.GetByMarca(marca);

            var masiniToReturn = new List<MasinaDTO>();

            foreach (var masina in masini)
            {
                masiniToReturn.Add(new MasinaDTO(masina));
            }

            return Ok(masiniToReturn);
        }
        [HttpGet("{id_masina:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetById(int id_masina)
        {
            var masina = await _repository.Masina.GetByIdAsync(id_masina);

            return Ok(new MasinaDTO(masina));
        }
        [HttpGet("cu_user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMasiniWithUser()
        {
            var masini = await _repository.Masina.GetMasiniWithUser();

            var masiniToReturn = new List<MasinaDTO>();

            foreach (var masina in masini)
            {
                masiniToReturn.Add(new MasinaDTO(masina));
            }

            return Ok(masiniToReturn);
        }
        [HttpGet("get_dotare/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllDotari(int id_masina)
        {
            var dotari = await _repository.Masina.GetAllDotari(id_masina);

            var dotariToReturn = new List<DotareDTO>();

            foreach (var dotare in dotari)
            {
                dotariToReturn.Add(new DotareDTO(dotare));
            }

            return Ok(dotariToReturn);
        }
        [HttpGet("get_rezervare/{id_user:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetMasinaRezervata(int id_user)
        {
            var masina = await _repository.Masina.GetMasinaRezervata(id_user);

            if (masina.Count>0)
                return Ok(new MasinaDTO(masina[0]));

            return BadRequest("Userul nu are masina rezervata");
        }
        [HttpGet("de_vanzare")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetMasiniWithoutUser()
        {
            var masini = await _repository.Masina.GetMasiniWithoutUser();

            var masiniToReturn = new List<MasinaDTO>();

            foreach (var masina in masini)
            {
                masiniToReturn.Add(new MasinaDTO(masina));
            }

            return Ok(masiniToReturn);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMasina(CreateMasinaDTO dto)
        {
            Masina newMasina = new Masina();

            newMasina.Marca = dto.Marca;
            newMasina.Model = dto.Model;
            newMasina.Culoare = dto.Culoare;
            newMasina.AnFabricare = dto.AnFabricare;
            newMasina.Km = dto.Km;
            newMasina.Cost = dto.Cost;
            newMasina.Descriere = dto.Descriere;

            _repository.Masina.Create(newMasina);

            await _repository.SaveAsync();

            return Ok(new MasinaDTO(newMasina));
        }
        [HttpPut("update_masina/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMasina(int id , UpdateMasinaDTO dto)
        {
            Masina masina = new Masina();

            masina = await _repository.Masina.GetByIdAsync(id);
            masina.Marca = dto.Marca;
            masina.Model = dto.Model;
            masina.Culoare = dto.Culoare;
            masina.AnFabricare = dto.AnFabricare;
            masina.Km = dto.Km;
            masina.Cost = dto.Cost;
            masina.Descriere = dto.Descriere;

            _repository.Masina.Update(masina);

            await _repository.SaveAsync();

            return Ok(new MasinaDTO(masina));
        }
        [HttpPut("update_masina_user/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMasinaUser(int id, UpdateUserMasinaDTO dto)
        {
            Masina masina = new Masina();

            masina = await _repository.Masina.GetByIdAsync(id);
            if (dto.UserId!=-1)
                masina.UserId = dto.UserId;
            else
                masina.UserId = null;


            _repository.Masina.Update(masina);


            await _repository.SaveAsync();


            return Ok(new MasinaDTO(masina));
        }
        [HttpPut("cerere_masina/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> CerereMasina(int id, UpdateUserMasinaDTO dto)
        {
            Masina masina = new Masina();

            masina = await _repository.Masina.GetByIdAsync(id);
            if (masina.UserId == null)
                masina.UserId = dto.UserId;
            else return BadRequest("Masina deja este rezervata");

            _repository.Masina.Update(masina);


            await _repository.SaveAsync();


            return Ok(new MasinaDTO(masina));
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMasina(int id)
        {
            Masina masina = new Masina();

            masina = await _repository.Masina.GetByIdAsync(id);

            _repository.Masina.Delete(masina);

            await _repository.SaveAsync();

            return Ok(new MasinaDTO(masina));
        }
    }
}
