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
    public interface IServiceDetailsService
    {
        Task<GenericResult<viewServiceDetails>> Add(ServiceDetails data);
        Task<GenericResult<viewServiceDetails>> Update(ServiceDetails data);
        Task<GenericResult<ServiceDetails>> Delete(int id);
        Task<GenericResult<ServiceDetails>> Get(int id);
        IQueryable<viewServiceDetails> GetAll(Expression<Func<viewServiceDetails, bool>>? filter = null, Func<IQueryable<viewServiceDetails>, IOrderedQueryable<viewServiceDetails>>? orderBy = null);
    }
}
