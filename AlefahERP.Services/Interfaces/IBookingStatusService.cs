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
    public interface IBookingStatusService
    {
        Task<GenericResult<BookingStatus>> Add(BookingStatus data);
        Task<GenericResult<BookingStatus>> Update(BookingStatus data);
        Task<GenericResult<BookingStatus>> Delete(int id);
        Task<GenericResult<BookingStatus>> Get(int id);
        IQueryable<BookingStatus> GetAll(Expression<Func<BookingStatus, bool>>? filter = null, Func<IQueryable<BookingStatus>, IOrderedQueryable<BookingStatus>>? orderBy = null);
    }
}
