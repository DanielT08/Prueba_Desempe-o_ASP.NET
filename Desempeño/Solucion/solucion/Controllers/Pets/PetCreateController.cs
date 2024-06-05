using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Services.Pets;

namespace solucion.Controllers
{
    public class PetCreateController : ControllerBase
    {
        private readonly IPetRepository _PetRepository;
        public PetCreateController(IPetRepository PetRepository)
        {
            _PetRepository = PetRepository;
        }

        [HttpPost, Route("api/pets")]
        public IActionResult create([FromBody] Pet Pet)
        {
            try
            {
                _PetRepository.CreatePet(pet);

                var response = new
                {
                    Message = "Esta mascota se creo con exito.",
                    Pet = Pet
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear mascota: {ex.Message}");
                return BadRequest("Se produjo un error al crear la mascota.");
            }
        }
    }
}
