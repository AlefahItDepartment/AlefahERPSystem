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
    public interface IPetBloodChemistryDetailsService
    {
        Task<GenericResult<PetBloodChemistryDetails>> Add(PetBloodChemistryDetails data);
        Task<GenericResult<PetBloodChemistryDetails>> Update(PetBloodChemistryDetails data);
        Task<GenericResult<PetBloodChemistryDetails>> Delete(int id);
        Task<GenericResult<PetBloodChemistryDetails>> Get(int id);
        IQueryable<PetBloodChemistryDetails> GetAll(Expression<Func<PetBloodChemistryDetails, bool>>? filter = null, Func<IQueryable<PetBloodChemistryDetails>, IOrderedQueryable<PetBloodChemistryDetails>>? orderBy = null);
    }
}
