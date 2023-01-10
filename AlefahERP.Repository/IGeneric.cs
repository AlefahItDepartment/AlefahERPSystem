using AlefahERP.Common;
using System.Linq.Expressions;

namespace AlefahERP.Repository
{
    public interface IGeneric<T, U>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> GetById(U id);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

    }
}