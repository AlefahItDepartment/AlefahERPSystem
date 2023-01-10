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
    public interface IPetExamineTypesService
    {
        Task<GenericResult<PetExamineTypes>> Add(PetExamineTypes data);
        Task<GenericResult<PetExamineTypes>> Update(PetExamineTypes data);
        Task<GenericResult<PetExamineTypes>> Delete(int id);
        Task<GenericResult<PetExamineTypes>> Get(int id);
        IQueryable<PetExamineTypes> GetAll(Expression<Func<PetExamineTypes, bool>>? filter = null, Func<IQueryable<PetExamineTypes>, IOrderedQueryable<PetExamineTypes>>? orderBy = null);
    }
}
