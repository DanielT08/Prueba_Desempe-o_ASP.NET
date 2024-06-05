using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solucion.Models;

namespace solucion.Services.Owners
{
    public interface IOwnerRepository
    {
        List<Owner> GetOwners();
        Owner GetOwner(int id);
        void CreateOwner(Owner owner);
        void UpdateOwner(Owner owner);
        bool ExistEmail(string email, int idOwnerExcluido);
    }
}