using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class BookingStatusRepository : IBookingStatusRepository
    {
        private readonly AlefahDbContext db;
        public BookingStatusRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public BookingStatus Add(BookingStatus entity)
        {
            try
            {               
                 this.db.BookingStatus.Add(entity);
                   
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BookingStatus Delete(BookingStatus entity)
        {
            try
            {
                    if (entity != null)
                        this.db.BookingStatus.Remove(entity);
              
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BookingStatus> GetById(int id)
        {
            return await this.db.BookingStatus.FindAsync(id);
        }

        public IQueryable<BookingStatus> GetAll(Expression<Func<BookingStatus, bool>>? filter = null, Func<IQueryable<BookingStatus>, IOrderedQueryable<BookingStatus>>? orderBy = null)
        {
            try
            {

                IQueryable<BookingStatus> query = this.db.BookingStatus;
                if (filter != null)
                    query = query.Where(filter);
                if (orderBy != null)
                    query = orderBy(query);


                return query;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public BookingStatus Update(BookingStatus entity)
        {
            try
            {
              
                    this.db.BookingStatus.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
