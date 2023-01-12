using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Services.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Interfaces
{
    public interface IEmployees1Service
    {
        Task<GenericResult<Employees1>> Add(Employee1RequestModel data);
        Task<GenericResult<Employees1>> Update(Employee1RequestModel data);
        Task<GenericResult<Employees1>> Delete(int id);
        Task<GenericResult<Employees1>> Get(int id);
        IQueryable<Employees1> GetAll(Expression<Func<Employees1, bool>>? filter = null, Func<IQueryable<Employees1>, IOrderedQueryable<Employees1>>? orderBy = null);
    }
}
