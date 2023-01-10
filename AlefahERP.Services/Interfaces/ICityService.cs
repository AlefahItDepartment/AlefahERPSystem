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
    public interface ICityService
    {
        Task<GenericResult<City>> Add(City data);
        Task<GenericResult<City>> Update(City data);
        Task<GenericResult<City>> Delete(int id);
        Task<GenericResult<City>> Get(int id);
        IQueryable<City> GetAll(Expression<Func<City, bool>>? filter = null, Func<IQueryable<City>, IOrderedQueryable<City>>? orderBy = null);
    }
}
