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
    public interface IPetBloodScreenTypesService
    {
        Task<GenericResult<PetBloodScreenTypes>> Add(PetBloodScreenTypes data);
        Task<GenericResult<PetBloodScreenTypes>> Update(PetBloodScreenTypes data);
        Task<GenericResult<PetBloodScreenTypes>> Delete(int id);
        Task<GenericResult<PetBloodScreenTypes>> Get(int id);
        IQueryable<PetBloodScreenTypes> GetAll(Expression<Func<PetBloodScreenTypes, bool>>? filter = null, Func<IQueryable<PetBloodScreenTypes>, IOrderedQueryable<PetBloodScreenTypes>>? orderBy = null);
    }
}
