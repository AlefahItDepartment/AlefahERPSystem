using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface ICustomersPETRepository:IGeneric<CustomersPET,int>
    {
        IQueryable<viewCustomersPET> GetAllCustomersPET(Expression<Func<viewCustomersPET, bool>>? filter = null, Func<IQueryable<viewCustomersPET>, IOrderedQueryable<viewCustomersPET>>? orderBy=null);

    }
}
