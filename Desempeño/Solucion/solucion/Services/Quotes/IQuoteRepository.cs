using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solucion.Models;
using solucion.Utils;

namespace solucion.Services.Quotes
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAll();
        Task<ResponseUtils<Quote>> CreateQuote(Quote quote, int Vetid, int OwnerId, DateTime Date);

    }
}