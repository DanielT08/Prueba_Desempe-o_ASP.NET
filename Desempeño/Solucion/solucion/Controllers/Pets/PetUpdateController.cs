using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Services.Pets;

namespace solucion.Controllers
{
    public class PetUpdateController : ControllerBase
    {
        private readonly IPetRepository _PetRepository;
        public PetUpdateController(IPetRepository PetRepository)
        {
            _PetRepository = PetRepository;
        }
        
        [HttpPut, Route("api/pets/{id}")]
        public IActionResult UpdatePet([FromBody] Pet pet)
        {
            try{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var response = new
                {
                    Message = "Esta mascota se edito con exito.",
                    Pet = Pet
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}

    