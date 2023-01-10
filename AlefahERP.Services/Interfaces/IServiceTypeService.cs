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
    public interface IServiceTypeService
    {
        Task<GenericResult<ServiceType>> Add(ServiceType data);
        Task<GenericResult<ServiceType>> Update(ServiceType data);
        Task<GenericResult<ServiceType>> Delete(int id);
        Task<GenericResult<ServiceType>> Get(int id);
        IQueryable<ServiceType> GetAll(Expression<Func<ServiceType, bool>>? filter = null, Func<IQueryable<ServiceType>, IOrderedQueryable<ServiceType>>? orderBy = null);
    }
}
