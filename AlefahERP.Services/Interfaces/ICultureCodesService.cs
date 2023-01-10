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
    public interface ICultureCodesService
    {
        Task<GenericResult<CultureCodes>> Add(CultureCodes data);
        Task<GenericResult<CultureCodes>> Update(CultureCodes data);
        Task<GenericResult<CultureCodes>> Delete(int id);
        Task<GenericResult<CultureCodes>> Get(int id);
        IQueryable<CultureCodes> GetAll(Expression<Func<CultureCodes, bool>>? filter = null, Func<IQueryable<CultureCodes>, IOrderedQueryable<CultureCodes>>? orderBy = null);
    }
}
