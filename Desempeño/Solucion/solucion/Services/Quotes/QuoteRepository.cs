using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using solucion.Data;
using solucion.Models;
using solucion.Services;
using solucion.Utils;

namespace solucion.Services.Quotes
{
    public class QuoteRepository: IQuoteRepository
    {
        public readonly BaseContext _context;
        public QuoteRepository(BaseContext context)
        {
            _context = context;
        }

         public async Task<IEnumerable<Quote>> GetAll()
        {
            return await _context.Quotes.ToListAsync();
        }
        public async Task<ResponseUtils<Quote>> CreateQuote(Quote quote, int VetId, int PetId, DateTime quoteDate)
        {
            
            try
           
            { 
                var existQuote = await _context.Quotes.FirstOrDefaultAsync(c => (c.VetId == VetId && 
                c.PetId == OwnerId && c.Date == quoteDate ) || 
                (c.VetId == VetId && c.Date == quoteDate ) || 
                (c.PetId == OwnerId && c.Date == quoteDate ));

                 if (existQuote == null)
                 {
                    _context.Quotes.Add(quote);
                    await _context.SaveChangesAsync();

                    var quote = await _context.Quotes.FirstOrDefaultAsync(c => c.Id == quote.PetId);

                    var sendEmail = new MailersendUtils();

                    sendEmail. SendEmail(Pet.Email, quote.Date);

                    return new ResponseUtils<Quote>(true, new List<Quote>{quote}, 201, message: "¡La cita ha sido registrada!");
                }
                else
                {
                    return new ResponseUtils<Quote>(false, null, 406, message: "¡La cita se interpone con otra!");
                }
                 
            }
            catch (Exception ex)
            {

                return new ResponseUtils<Quote>(false, null, 422, message: ex.Message);

            }
            
        }
    }
}