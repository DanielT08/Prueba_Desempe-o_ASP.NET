using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Services.Owners;

namespace solucion.Controllers
{
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnerRepository _OwnerRepository;
        public OwnerCreateController(IOwnerRepository OwnerRepository)
        {
            _OwnerRepository = OwnerRepository;
        }

        [HttpPost, Route("api/owners")]
        public IActionResult create([FromBody] Owner Owner)
        {
            try
            {
                _OwnerRepository.CreateOwner(owner);

                var response = new
                {
                    Message = "Este dueño se creo con exito.",
                    Owner = owner
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear dueño: {ex.Message}");
                return BadRequest("Se produjo un error al crear el dueño.");
            }
        }
    }
}
