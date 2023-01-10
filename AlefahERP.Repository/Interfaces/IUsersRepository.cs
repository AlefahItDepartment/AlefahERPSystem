using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IUsersRepository:IGeneric<Users,int>
    {

        IQueryable<viewUsers> GetAllUsers(Expression<Func<viewUsers, bool>>? filter = null, Func<IQueryable<viewUsers>, IOrderedQueryable<viewUsers>>? orderBy = null);
    }
}
