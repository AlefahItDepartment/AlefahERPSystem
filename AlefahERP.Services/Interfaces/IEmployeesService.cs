using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Common.RequestModels;
using AlefahERP.Common.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<GenericResult<EmployeeResponseModel>> Add(EmployeeRequestModel data);
        Task<GenericResult<EmployeeResponseModel>> Update(EmployeeRequestModel data);
        Task<GenericResult<Employees>> Delete(int id);
        Task<GenericResult<Employees>> Get(int id);
        IQueryable<viewEmployees> GetAll(Expression<Func<viewEmployees, bool>>? filter = null, Func<IQueryable<viewEmployees>, IOrderedQueryable<viewEmployees>>? orderBy = null);
    }
}
