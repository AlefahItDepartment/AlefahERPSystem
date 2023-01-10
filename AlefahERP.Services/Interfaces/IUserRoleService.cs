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
    public interface IUserRoleService
    {
        Task<GenericResult<UserRole>> Add(UserRole data);
        Task<GenericResult<UserRole>> Update(UserRole data);
        Task<GenericResult<UserRole>> Delete(int id);
        Task<GenericResult<UserRole>> Get(int id);
        IQueryable<UserRole> GetAll(Expression<Func<UserRole, bool>>? filter = null, Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy = null);
    }
}
