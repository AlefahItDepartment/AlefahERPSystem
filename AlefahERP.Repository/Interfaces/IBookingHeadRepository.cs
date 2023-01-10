using AlefahERP.DTO;
using System.Linq.Expressions;

namespace AlefahERP.Repository.Interfaces
{
    public interface IBookingHeadRepository : IGeneric<BookingHead, int>
    {
        IQueryable<viewBookingHead> GetAllBookingHead(Expression<Func<viewBookingHead, bool>>? filter = null, Func<IQueryable<viewBookingHead>, IOrderedQueryable<viewBookingHead>>? orderBy = null);
        Task<string> BookingNumber(int id);
        IEnumerable<_ApointmentsCounter> GetApointmentsCounters(DateTime fromDate, DateTime toDate, int? branchID = null, int? customerID = null, int? assignFromUserID = null, int? assignToUserID = null, int? closeUserID = null);

    }
}
