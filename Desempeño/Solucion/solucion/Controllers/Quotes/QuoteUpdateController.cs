using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using solucion.Models;
using solucion.Services.Quotes;

namespace solucion.Controllers
{
    public class QuoteUpdateController : ControllerBase
    {
        private readonly IQuoteRepository _QuoteRepository;
        public QuoteUpdateController(IQuoteRepository QuoteRepository)
        {
            _QuoteRepository = QuoteRepository;
        }
        
        [HttpPut, Route("api/quotes/{id}")]
        public IActionResult UpdateQuote([FromBody] Quote quote)
        {
            try{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
        
                var response = new
                {
                    Message = "Esta cita se edito con exito.",
                    Quote = Quote
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

    