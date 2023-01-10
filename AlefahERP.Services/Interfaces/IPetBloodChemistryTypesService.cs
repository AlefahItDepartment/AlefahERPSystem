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
    public interface IPetBloodChemistryTypesService
    {
        Task<GenericResult<PetBloodChemistryTypes>> Add(PetBloodChemistryTypes data);
        Task<GenericResult<PetBloodChemistryTypes>> Update(PetBloodChemistryTypes data);
        Task<GenericResult<PetBloodChemistryTypes>> Delete(int id);
        Task<GenericResult<PetBloodChemistryTypes>> Get(int id);
        IQueryable<PetBloodChemistryTypes> GetAll(Expression<Func<PetBloodChemistryTypes, bool>>? filter = null, Func<IQueryable<PetBloodChemistryTypes>, IOrderedQueryable<PetBloodChemistryTypes>>? orderBy = null);
    }
}
