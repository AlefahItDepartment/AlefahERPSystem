using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface ICustomersAddressLinesRepository:IGeneric<CustomersAddressLines,int>
    {
        IQueryable<viewCustomerAddressLines> GetAllCustomersAddressLines(Expression<Func<viewCustomerAddressLines, bool>>? filter = null, Func<IQueryable<viewCustomerAddressLines>, IOrderedQueryable<viewCustomerAddressLines>>? orderBy = null);

    }
}
