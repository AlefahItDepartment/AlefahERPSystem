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
    public interface IPetColorsService
    {
        Task<GenericResult<PetColors>> Add(PetColors data);
        Task<GenericResult<PetColors>> Update(PetColors data);
        Task<GenericResult<PetColors>> Delete(int id);
        Task<GenericResult<PetColors>> Get(int id);
        IQueryable<PetColors> GetAll(Expression<Func<PetColors, bool>>? filter = null, Func<IQueryable<PetColors>, IOrderedQueryable<PetColors>>? orderBy = null);
    }
}
