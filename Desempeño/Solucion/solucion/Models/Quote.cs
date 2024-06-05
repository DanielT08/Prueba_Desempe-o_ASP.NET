using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solucion.Models
{
    public class Quote
    {

        public int Id { get; set; }

        public int PetId { get; set; }
        
        public int VetId { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        // FOREIGN KEYS:
        public Pet? Pet { get; set; }
        public Vet? Vet { get; set; }
        
    }
}
