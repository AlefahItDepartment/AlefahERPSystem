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
    public interface ICustomersAddressLinesService
    {
        Task<GenericResult<viewCustomerAddressLines>> Add(CustomersAddressLines data);
        Task<GenericResult<viewCustomerAddressLines>> Update(CustomersAddressLines data);
        Task<GenericResult<CustomersAddressLines>> Delete(int id);
        Task<GenericResult<CustomersAddressLines>> Get(int id);
        IQueryable<viewCustomerAddressLines> GetAll(Expression<Func<viewCustomerAddressLines, bool>>? filter = null, Func<IQueryable<viewCustomerAddressLines>, IOrderedQueryable<viewCustomerAddressLines>>? orderBy = null);
    }
}
