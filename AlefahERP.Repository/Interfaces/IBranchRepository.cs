using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IBranchRepository:IGeneric<Branch,int>
    {
        IQueryable<viewBranch> GetAllBranchs(Expression<Func<viewBranch, bool>>? filter = null, Func<IQueryable<viewBranch>, IOrderedQueryable<viewBranch>>? orderBy = null);

    }
}
