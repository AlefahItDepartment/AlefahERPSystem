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
    public interface IDesignationService
    {
        Task<GenericResult<Designation>> Add(Designation data);
        Task<GenericResult<Designation>> Update(Designation data);
        Task<GenericResult<Designation>> Delete(int id);
        Task<GenericResult<Designation>> Get(int id);
       IQueryable<Designation> GetAll(Expression<Func<Designation, bool>>? filter = null, Func<IQueryable<Designation>, IOrderedQueryable<Designation>>? orderBy = null);
    }
}
