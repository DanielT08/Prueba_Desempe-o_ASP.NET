using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solucion.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Specie { get; set; }
        public string? Race { get; set; }
        public DateTime DateBirth { get; set; }
        public string Photo { get; set; }
     // FOREIGN KEY:
        public Owner? Owner { get; set; }
    }
}
