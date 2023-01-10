using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IEmployeesRepository:IGeneric<Employees, int>
    {
        IQueryable<viewEmployees> GetAllEmployees(Expression<Func<viewEmployees, bool>>? filter = null, Func<IQueryable<viewEmployees>, IOrderedQueryable<viewEmployees>>? orderBy = null);
    }
}
