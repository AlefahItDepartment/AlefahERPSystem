using AlefahERP.Common;
using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Bookings.Interfaces
{
    public interface IBookingDetailsService
    {
        Task<GenericResult<viewBookingDetails>> Add(BookingDetails data);
        Task<GenericResult<viewBookingDetails>> Update(BookingDetails data);
        Task<GenericResult<BookingDetails>> Delete(int id);
        Task<GenericResult<BookingDetails>> Get(int id);
        IQueryable<viewBookingDetails> GetAll(Expression<Func<viewBookingDetails, bool>>? filter = null, Func<IQueryable<viewBookingDetails>, IOrderedQueryable<viewBookingDetails>>? orderBy = null);
    }
}
