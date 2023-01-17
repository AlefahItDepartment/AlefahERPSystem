using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Common.RequestModels;
using AlefahERP.Common.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<GenericResult<CustomerResponseModel>> Add(CustomerRequestModel data);
        Task<GenericResult<CustomerResponseModel>> Update(CustomerRequestModel data);
        Task<GenericResult<Customers>> Delete(int id);
        Task<GenericResult<Customers>> Get(int id);
        IQueryable<viewCustomers> GetAll(Expression<Func<viewCustomers, bool>>? filter = null, Func<IQueryable<viewCustomers>, IOrderedQueryable<viewCustomers>>? orderBy = null);
    }
}
