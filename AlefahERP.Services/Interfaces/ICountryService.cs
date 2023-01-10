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
    public interface ICountryService
    {
        Task<GenericResult<Country>> Add(Country data);
        Task<GenericResult<Country>> Update(Country data);
        Task<GenericResult<Country>> Delete(int id);
        Task<GenericResult<Country>> Get(int id);
        IQueryable<Country> GetAll(Expression<Func<Country, bool>>? filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null);
    }
}
