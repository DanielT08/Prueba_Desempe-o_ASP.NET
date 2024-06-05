using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solucion.Data;
using solucion.Models;
using solucion.Services;

namespace solucion.Services.Owners
{
    public class OwnerRepository: IOwnerRepository
    {
        private readonly BaseContext _context;
        public OwnerRepository(BaseContext context)
        {
            _context = context;
        }

        public List<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.FirstOrDefault(p => p.Id == id);
        }

        public void CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public void UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
            _context.SaveChanges();
        }
        public bool ExistEmail(string email, int idOwnerExcluido)
        {
            return _context.Owners.Any(m => m.Emial == email && m.Id != idOwnerExcluido);
        }
    }
}