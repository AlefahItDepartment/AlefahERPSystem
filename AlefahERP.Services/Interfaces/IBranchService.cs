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
    public interface IBranchService
    {
        Task<GenericResult<Branch>> Add(Branch data);
        Task<GenericResult<Branch>> Update(Branch data);
        Task<GenericResult<Branch>> Delete(int id);
        Task<GenericResult<Branch>> Get(int id);
        IQueryable<Branch> GetAll(Expression<Func<Branch, bool>>? filter = null, Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy = null);
    }
}
