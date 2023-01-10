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
    public interface IPetExamineDetailsService
    {
        Task<GenericResult<PetExamineDetails>> Add(PetExamineDetails data);
        Task<GenericResult<PetExamineDetails>> Update(PetExamineDetails data);
        Task<GenericResult<PetExamineDetails>> Delete(int id);
        Task<GenericResult<PetExamineDetails>> Get(int id);
        IQueryable<PetExamineDetails> GetAll(Expression<Func<PetExamineDetails, bool>>? filter = null, Func<IQueryable<PetExamineDetails>, IOrderedQueryable<PetExamineDetails>>? orderBy = null);
    }
}
