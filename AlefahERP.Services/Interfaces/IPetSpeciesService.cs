using AlefahERP.Common;
using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Interfaces
{
    public interface IPetSpeciesService
    {
        Task<GenericResult<PetSpecies>> Add(PetSpecies data);
        Task<GenericResult<PetSpecies>> Update(PetSpecies data);
        Task<GenericResult<PetSpecies>> Delete(int id);
        Task<GenericResult<PetSpecies>> Get(int id);
        IQueryable<PetSpecies> GetAll(Expression<Func<PetSpecies, bool>>? filter = null, Func<IQueryable<PetSpecies>, IOrderedQueryable<PetSpecies>>? orderBy = null);
    }
}
