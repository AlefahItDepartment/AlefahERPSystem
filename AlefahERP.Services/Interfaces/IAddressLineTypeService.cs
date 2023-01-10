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
    public interface IAddressLineTypeService
    {
        Task<GenericResult<AddressLineType>> Add(AddressLineType data);
        Task<GenericResult<AddressLineType>> Update(AddressLineType data);
        Task<GenericResult<AddressLineType>> Delete(int id);
        Task<GenericResult<AddressLineType>> Get(int id);
        IQueryable<AddressLineType> GetAll(Expression<Func<AddressLineType, bool>>? filter = null, Func<IQueryable<AddressLineType>, IOrderedQueryable<AddressLineType>>? orderBy = null);
    }
}
