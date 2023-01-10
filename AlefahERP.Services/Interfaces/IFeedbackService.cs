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
    public interface IFeedbackService
    {
        Task<GenericResult<Feedback>> Add(Feedback data);
        Task<GenericResult<Feedback>> Update(Feedback data);
        Task<GenericResult<Feedback>> Delete(int id);
        Task<GenericResult<Feedback>> Get(int id);
        IQueryable<Feedback> GetAll(Expression<Func<Feedback, bool>>? filter = null, Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>>? orderBy = null);
    }
}
