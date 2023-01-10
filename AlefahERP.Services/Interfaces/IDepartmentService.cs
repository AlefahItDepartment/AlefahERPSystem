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
    public interface IDepartmentService
    {
        Task<GenericResult<Department>> Add(Department data);
        Task<GenericResult<Department>> Update(Department data);
        Task<GenericResult<Department>> Delete(int id);
        Task<GenericResult<Department>> Get(int id);
        IQueryable<Department> GetAll(Expression<Func<Department, bool>>? filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>>? orderBy = null);
    }
}
