using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Services.Owners;
using solucion.Models;

namespace solucion.Controllers.Owners
{
    public class OwnersController: ControllerBase
    {
        private readonly IOwnerRepository _OwnerRepository;
        public OwnersController(IOwnerRepository OwnerRepository)
        {
            _OwnerRepository = OwnerRepository;
        }

        [HttpGet, Route("api/owner")]
        public IActionResult Get()
        {
            return Ok(_OwnerRepository.GetOwners());
        }

        [HttpGet, Route("api/owners/{id}")]
        public IActionResult Get(int id)
        {
            var owner = _OwnerRepository.GetOwner(id);
            try{
                if (owner == null)
                {   
                    return NotFound($"No se encontró ningún dueño con el ID: {id}");
                }

                var response = new
                {
                    Message = "Este es el dueño solicitado.",
                    owner = owner
                };

                return Ok(response);
            }
            catch (Exception ex)
            {   return Problem(
                    statusCode: 500,
                    title: "Error interno",
                    detail: $"Ocurrió un error al obtener el dueño. {ex.Message}"
                );
            }   
        }
    }
}