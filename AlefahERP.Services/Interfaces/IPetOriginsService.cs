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
    public interface IPetOriginsService
    {
        Task<GenericResult<PetOrigins>> Add(PetOrigins data);
        Task<GenericResult<PetOrigins>> Update(PetOrigins data);
        Task<GenericResult<PetOrigins>> Delete(int id);
        Task<GenericResult<PetOrigins>> Get(int id);
        IQueryable<PetOrigins> GetAll(Expression<Func<PetOrigins, bool>>? filter = null, Func<IQueryable<PetOrigins>, IOrderedQueryable<PetOrigins>>? orderBy = null);
    }
}
