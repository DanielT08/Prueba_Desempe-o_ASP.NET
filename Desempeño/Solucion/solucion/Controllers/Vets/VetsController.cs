using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solucion.Data;
using solucion.Models;
using solucion.Services.Vets;

namespace solucion.Controllers.Vets
{
    public class VetsController: ControllerBase
    {
       private readonly IVetsRepository _VetRepository;
        public VetsController(IVetsRepository _VetRepository)
        {
            __VetRepository = _VetRepository;
        }

        [HttpGet, Route("api/vet")]
        public IActionResult Get()
        {
            return Ok(__VetRepository.GetVets());
        }

        [HttpGet, Route("api/vets/{id}")]
        public IActionResult Get(int id)
        {
            var vet = _VetRepository.GetVet(id);
            try{
                if (vet == null)
                {   
                    return NotFound($"No se encontró ningún veterinario con el ID: {id}");
                }

                var response = new
                {
                    Message = "Este es el veterinario solicitado.",
                    vet = vet
                };

                return Ok(response);
            }
            catch (Exception ex)
            {   return Problem(
                    statusCode: 500,
                    title: "Error interno",
                    detail: $"Ocurrió un error al obtener el veterinario. {ex.Message}"
                );
            }   
        } 
    }
}