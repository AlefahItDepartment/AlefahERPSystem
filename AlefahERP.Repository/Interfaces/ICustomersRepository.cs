using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface ICustomersRepository : IGeneric<Customers, int>
    {
        IQueryable<viewCustomers> GetAllCustomers(Expression<Func<viewCustomers, bool>>? filter = null, Func<IQueryable<viewCustomers>, IOrderedQueryable<viewCustomers>>? orderBy = null);
        Task<string> FileNumber();
    }
}
