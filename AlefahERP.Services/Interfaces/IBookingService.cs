using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Common.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Interfaces
{
    public interface IBookingService
    {
        Task<GenericResult<viewBookingHead>> Add(BookingRequestModel data);
        Task<GenericResult<viewBookingHead>> Update(BookingRequestModel data);
        Task<GenericResult<viewBookingHead>> Delete(int id);
        Task<GenericResult<BookingHead>> Get(int id);
        IQueryable<viewBookingHead> GetAll(Expression<Func<viewBookingHead, bool>>? filter = null, Func<IQueryable<viewBookingHead>, IOrderedQueryable<viewBookingHead>>? orderBy = null);
    }
}
