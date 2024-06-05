using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solucion.Data;
using solucion.Models;
using solucion.Services.Quotes;

namespace solucion.Controllers
{
    public class QuotesController: ControllerBase
    {
        public readonly IQuoteRepository _QuoteRepository;
        public QuotesController(IQuoteRepository QuoteRepository)
        {
            _QuoteRepository = QuoteRepository;
        }

        [HttpGet, Route("api/quotes")]
        public async Task<IEnumerable<Quote>> GetAll()
        {
            return await _QuoteRepository.GetAll();
        }
    }
};