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
    public class PiesaController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PiesaController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllPiese()
        {
            var piese = await _repository.Piesa.GetAllPiese();

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpGet("cu_tip/{tip}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetByTip(string tip)
        {
            var piese = await _repository.Piesa.GetByTip(tip);

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpGet("{id_piesa:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetById(int id_piesa)
        {
            var piesa = await _repository.Piesa.GetByIdAsync(id_piesa);

            return Ok(new PiesaDTO(piesa));
        }
        [HttpGet("/cu_producator/{producator}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetByProducator(string producator)
        {
            var piese = await _repository.Piesa.GetByTip(producator);

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpGet("cu_user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPieseWithUser()
        {
            var piese = await _repository.Piesa.GetPieseWithUser();

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpGet("get_cumparate_de_user/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetPieseCumparate(int id)
        {
            var piese = await _repository.Piesa.GetPieseCumparate(id);

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpGet("get_de_vanzare")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetPieseWithoutUser()
        {
            var piese = await _repository.Piesa.GetPieseWithoutUser();

            var pieseToReturn = new List<PiesaDTO>();

            foreach (var piesa in piese)
            {
                pieseToReturn.Add(new PiesaDTO(piesa));
            }

            return Ok(pieseToReturn);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePiesa(CreatePiesaDTO dto)
        {
            Piesa newPiesa = new Piesa();

            newPiesa.Cost = dto.Cost;
            newPiesa.Tip = dto.Tip;
            newPiesa.Producator = dto.Producator;
            newPiesa.AnFabricatie = dto.AnFabricatie;
            newPiesa.Serie = dto.Serie;
            newPiesa.Descriere = dto.Descriere;

            _repository.Piesa.Create(newPiesa);

            await _repository.SaveAsync();

            return Ok(new PiesaDTO(newPiesa));
        }
        [HttpPut("update_piesa/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePiesa(int id, UpdatePiesaDTO dto)
        {
            Piesa piesa = new Piesa();

            piesa = await _repository.Piesa.GetByIdAsync(id);
            piesa.Cost = dto.Cost;
            piesa.Tip = dto.Tip;
            piesa.Producator = dto.Producator;
            piesa.AnFabricatie = dto.AnFabricatie;
            piesa.Serie = dto.Serie;
            piesa.Descriere = dto.Descriere;

            _repository.Piesa.Update(piesa);

            await _repository.SaveAsync();

            return Ok(new PiesaDTO(piesa));
        }
        [HttpPut("update_piesa_user/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePiesaUser(int id, UpdateUserPiesaDTO dto)
        {
            Piesa piesa = new Piesa();

            piesa = await _repository.Piesa.GetByIdAsync(id);
            if (dto.UserId != -1)
                piesa.UserId = dto.UserId;
            else
                piesa.UserId = null;

            _repository.Piesa.Update(piesa);


            await _repository.SaveAsync();


            return Ok(new PiesaDTO(piesa));
        }
        [HttpPut("comanda_piesa/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ComandaPiesa(int id, UpdateUserPiesaDTO dto)
        {
            Piesa piesa = new Piesa();

            piesa = await _repository.Piesa.GetByIdAsync(id);
            if (piesa.UserId == null)
                piesa.UserId = dto.UserId;
            else return BadRequest("Piesa este deja comandata");

            _repository.Piesa.Update(piesa);


            await _repository.SaveAsync();


            return Ok(new PiesaDTO(piesa));
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePiesa(int id)
        {
            Piesa piesa = new Piesa();

            piesa = await _repository.Piesa.GetByIdAsync(id);

            _repository.Piesa.Delete(piesa);

            await _repository.SaveAsync();

            return Ok(new PiesaDTO(piesa));
        }
    }
}
