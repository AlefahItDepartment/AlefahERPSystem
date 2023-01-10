using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IBookingDetailsRepository : IGeneric<BookingDetails, int>
    {
        IQueryable<viewBookingDetails> GetAllBookingDetails(Expression<Func<viewBookingDetails, bool>>? filter = null, Func<IQueryable<viewBookingDetails>, IOrderedQueryable<viewBookingDetails>>? orderBy = null);

    }
}
