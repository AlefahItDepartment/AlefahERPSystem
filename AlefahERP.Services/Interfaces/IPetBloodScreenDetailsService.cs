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
    public interface IPetBloodScreenDetailsService
    {
        Task<GenericResult<PetBloodScreenDetails>> Add(PetBloodScreenDetails data);
        Task<GenericResult<PetBloodScreenDetails>> Update(PetBloodScreenDetails data);
        Task<GenericResult<PetBloodScreenDetails>> Delete(int id);
        Task<GenericResult<PetBloodScreenDetails>> Get(int id);
        IQueryable<PetBloodScreenDetails> GetAll(Expression<Func<PetBloodScreenDetails, bool>>? filter = null, Func<IQueryable<PetBloodScreenDetails>, IOrderedQueryable<PetBloodScreenDetails>>? orderBy = null);
    }
}
