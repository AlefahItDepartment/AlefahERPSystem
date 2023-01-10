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
    public interface IBranchSchedulesService
    {
        Task<GenericResult<BranchSchedules>> Add(BranchSchedules data);
        Task<GenericResult<BranchSchedules>> Update(BranchSchedules data);
        Task<GenericResult<BranchSchedules>> Delete(int id);
        Task<GenericResult<BranchSchedules>> Get(int id);
        IQueryable<BranchSchedules> GetAll(Expression<Func<BranchSchedules, bool>>? filter = null, Func<IQueryable<BranchSchedules>, IOrderedQueryable<BranchSchedules>>? orderBy = null);
    }
}
