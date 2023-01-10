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
    public interface IPetSubSpeciesService
    {
        Task<GenericResult<PetSubSpecies>> Add(PetSubSpecies data);
        Task<GenericResult<PetSubSpecies>> Update(PetSubSpecies data);
        Task<GenericResult<PetSubSpecies>> Delete(int id);
        Task<GenericResult<PetSubSpecies>> Get(int id);
        IQueryable<PetSubSpecies> GetAll(Expression<Func<PetSubSpecies, bool>>? filter = null, Func<IQueryable<PetSubSpecies>, IOrderedQueryable<PetSubSpecies>>? orderBy = null);
    }
}
