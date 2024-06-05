using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Services.Owners;

namespace solucion.Controllers
{
    public class OwnerUpdateController : ControllerBase
    {
        private readonly IOwnerRepository _OwnerRepository;
        public OwnerUpdateController(IOwnerRepository OwnerRepository)
        {
            _OwnerRepository = OwnerRepository;
        }
        
        [HttpPut, Route("api/owners/{id}")]
        public IActionResult UpdateOwner([FromBody] Owner owner)
        {
            try{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (_OwnerRepository.ExistEmail(Owner.Email, Owner.Id))
                
                    return Conflict("El correo ya está en uso por otro dueño.");
            
                _OwnerRepository.UpdateOwner(Owner);

                var response = new
                {
                    Message = "Este dueño se edito con exito.",
                    Owner = Owner
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

    