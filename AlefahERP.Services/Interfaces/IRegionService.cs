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
    public interface IRegionService
    {
        Task<GenericResult<Region>> Add(Region data);
        Task<GenericResult<Region>> Update(Region data);
        Task<GenericResult<Region>> Delete(int id);
        Task<GenericResult<Region>> Get(int id);
        IQueryable<Region> GetAll(Expression<Func<Region, bool>>? filter = null, Func<IQueryable<Region>, IOrderedQueryable<Region>>? orderBy = null);
    }
}
