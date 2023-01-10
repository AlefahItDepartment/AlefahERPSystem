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
    public interface IUsersService
    {
        Task<GenericResult<viewUsers>> Add(Users data);
        Task<GenericResult<viewUsers>> Update(Users data);
        Task<GenericResult<Users>> Delete(int id);
        Task<GenericResult<Users>> Get(int id);
        IQueryable<viewUsers> GetAll(Expression<Func<viewUsers, bool>>? filter = null, Func<IQueryable<viewUsers>, IOrderedQueryable<viewUsers>>? orderBy = null);
    }
}
