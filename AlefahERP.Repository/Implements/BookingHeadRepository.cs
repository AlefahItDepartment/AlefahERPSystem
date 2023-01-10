using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class BookingHeadRepository : IBookingHeadRepository
    {
        private readonly AlefahDbContext db;
        public BookingHeadRepository(AlefahDbContext db)
        {
            this.db = db;

        }
        public BookingHead Add(BookingHead entity)
        {
            try
            {


                this.db.BookingHead.Add(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> BookingNumber(int id)
        {
            ICollection<string> fileNumbers = new List<string>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "_AppointmentNumber";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@BranchID", Value = id, SqlDbType = SqlDbType.Int });

                await db.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fileNumbers.Add(reader.GetFieldValue<string>(0));
                    }
                }
            }

            return fileNumbers.FirstOrDefault();
        }

        public BookingHead Delete(BookingHead entity)
        {
            try
            {
                if (entity != null)
                    this.db.BookingHead.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BookingHead> GetById(int id)
        {
            return  await this.db.BookingHead.FindAsync(id);
        }

        public IQueryable<BookingHead> GetAll(Expression<Func<BookingHead, bool>>? filter = null, Func<IQueryable<BookingHead>, IOrderedQueryable<BookingHead>>? orderBy = null)
        {
            try
            {

                IQueryable<BookingHead> query = this.db.BookingHead;
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

        public IQueryable<viewBookingHead> GetAllBookingHead(Expression<Func<viewBookingHead, bool>>? filter = null, Func<IQueryable<viewBookingHead>, IOrderedQueryable<viewBookingHead>>? orderBy = null)
        {
            try
            {

                IQueryable<viewBookingHead> query = this.db.viewBookingHead;
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

        public IEnumerable<_ApointmentsCounter> GetApointmentsCounters(DateTime fromDate, DateTime toDate, int? branchID = null, int? customerID = null, int? assignFromUserID = null, int? assignToUserID = null, int? closeUserID = null)
        {
            try
            {
                return this.db._ApointmentsCounter.FromSqlRaw<_ApointmentsCounter>("EXEC _ApointmentsCounter {0},{1},{2},{3},{4},{5},{6}", fromDate, toDate, branchID, customerID, assignFromUserID, assignToUserID, closeUserID);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BookingHead Update(BookingHead entity)
        {
            try
            {

                this.db.BookingHead.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
