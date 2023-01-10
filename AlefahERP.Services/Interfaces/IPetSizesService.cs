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
    public interface IPetSizesService
    {
        Task<GenericResult<PetSizes>> Add(PetSizes data);
        Task<GenericResult<PetSizes>> Update(PetSizes data);
        Task<GenericResult<PetSizes>> Delete(int id);
        Task<GenericResult<PetSizes>> Get(int id);
        IQueryable<PetSizes> GetAll(Expression<Func<PetSizes, bool>>? filter = null, Func<IQueryable<PetSizes>, IOrderedQueryable<PetSizes>>? orderBy = null);
    }
}
