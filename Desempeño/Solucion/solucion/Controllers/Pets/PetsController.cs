using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Services.Pets;
using solucion.Models;


namespace solucion.Controllers.Pets
{
    public class PetsController
    {
        private readonly IPetRepository _PetRepository;
        public PetsController(IPetRepository PetRepository)
        {
            _PetRepository = PetRepository;
        }

        [HttpGet, Route("api/Pet")]
        public IActionResult Get()
        {
            return Ok(_PetRepository.GetPets());
        }

        [HttpGet, Route("api/Pets/{id}")]
        public IActionResult Get(int id)
        {
            var pet = _PetRepository.GetPet(id);
            try{
                if (pet == null)
                {   
                    return NotFound($"No se encontró ningúna mascota con el ID: {id}");
                }

                var response = new
                {
                    Message = "Este es la macota solicitado.",
                    Pet = Pet
                };

                return Ok(response);
            }
            catch (Exception ex)
            {   return Problem(
                    statusCode: 500,
                    title: "Error interno",
                    detail: $"Ocurrió un error al obtener la mascota. {ex.Message}"
                );
            }   
        }
    }
}