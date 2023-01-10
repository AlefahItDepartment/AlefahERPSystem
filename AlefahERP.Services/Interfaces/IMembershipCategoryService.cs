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
    public interface IMembershipCategoryService
    {
        Task<GenericResult<MembershipCategory>> Add(MembershipCategory data);
        Task<GenericResult<MembershipCategory>> Update(MembershipCategory data);
        Task<GenericResult<MembershipCategory>> Delete(int id);
        Task<GenericResult<MembershipCategory>> Get(int id);
        IQueryable<MembershipCategory> GetAll(Expression<Func<MembershipCategory, bool>>? filter = null, Func<IQueryable<MembershipCategory>, IOrderedQueryable<MembershipCategory>>? orderBy = null);
    }
}
