

using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        private readonly AlefahDbContext db;
        public BookingDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }
        public BookingDetails Add(BookingDetails entity)
        {
            try
            {
                this.db.BookingDetails.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BookingDetails Delete(BookingDetails entity)
        {
            try
            {

                if (entity != null)
                {
                    this.db.BookingDetails.Remove(entity);

                }
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BookingDetails> GetById(int id)
        {
            return await this.db.BookingDetails.FindAsync(id);
        }

        public IQueryable<BookingDetails> GetAll(Expression<Func<BookingDetails, bool>>? filter = null, Func<IQueryable<BookingDetails>, IOrderedQueryable<BookingDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<BookingDetails> query = this.db.BookingDetails;
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

        public IQueryable<viewBookingDetails> GetAllBookingDetails(Expression<Func<viewBookingDetails, bool>>? filter = null, Func<IQueryable<viewBookingDetails>, IOrderedQueryable<viewBookingDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<viewBookingDetails> query = this.db.viewBookingDetails;
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

        public BookingDetails Update(BookingDetails entity)
        {
            try
            {

                this.db.BookingDetails.Update(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}


