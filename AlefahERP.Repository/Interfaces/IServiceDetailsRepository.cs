using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IServiceDetailsRepository:IGeneric<ServiceDetails,int>
    {
        IQueryable<viewServiceDetails> GetViewServiceDetails(Expression<Func<viewServiceDetails, bool>>? filter = null, Func<IQueryable<viewServiceDetails>, IOrderedQueryable<viewServiceDetails>>? orderBy = null);
    }
}
