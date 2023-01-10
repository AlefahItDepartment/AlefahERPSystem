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
    public interface IPetBreedsService
    {
        Task<GenericResult<PetBreeds>> Add(PetBreeds data);
        Task<GenericResult<PetBreeds>> Update(PetBreeds data);
        Task<GenericResult<PetBreeds>> Delete(int id);
        Task<GenericResult<PetBreeds>> Get(int id);
        IQueryable<PetBreeds> GetAll(Expression<Func<PetBreeds, bool>>? filter = null, Func<IQueryable<PetBreeds>, IOrderedQueryable<PetBreeds>>? orderBy = null);
    }
}
