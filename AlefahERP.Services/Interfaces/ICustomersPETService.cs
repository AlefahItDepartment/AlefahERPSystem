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
    public interface ICustomersPETService
    {
        Task<GenericResult<viewCustomersPET>> Add(CustomersPET data);
        Task<GenericResult<viewCustomersPET>> Update(CustomersPET data);
        Task<GenericResult<CustomersPET>> Delete(int id);
        Task<GenericResult<CustomersPET>> Get(int id);
        IQueryable<viewCustomersPET> GetAll(Expression<Func<viewCustomersPET, bool>>? filter = null, Func<IQueryable<viewCustomersPET>, IOrderedQueryable<viewCustomersPET>>? orderBy = null);
    }
}
