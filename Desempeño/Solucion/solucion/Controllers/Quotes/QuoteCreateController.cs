using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using solucion.Data;
using solucion.Models;
using Microsoft.AspNetCore.Mvc;
using solucion.Services.Quotes;
using solucion.Utils;

namespace solucion.Controllers.Quotes
{
    public class QuoteCreateController: ControllerBase
    {
        private readonly IQuoteRepository _QuoteRepository;
       public QuoteCreateController(IQuoteRepository QuoteRepository)
       {
           _QuoteRepository = QuoteRepository;
       } 

       [HttpPost, Route("api/quotes")]
       public async Task<ActionResult<ResponseUtils<Quote>>> CreateQuote([FromBody] Quote quote)
       {
            var response = await _QuoteRepository.CreateQuote(quote, quote.VetId, quote.PetId, quote.Date);
            if(!response.Status)
            {
                return StatusCode(422, response);
            }
            return Ok(response);
       }
    }
}
       
