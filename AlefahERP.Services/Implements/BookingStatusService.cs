using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Services.Implements
{
    public class BookingStatusService : IBookingStatusService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IBookingStatusRepository BookingStatus;
        public BookingStatusService(
            AlefahDbContext alefahDb, 
            IBookingStatusRepository BookingStatus
            )
        {
            this.alefahDb = alefahDb;
            this.BookingStatus = BookingStatus;
        }
        public async Task<GenericResult<BookingStatus>> Add(BookingStatus data)
        {
            GenericResult<BookingStatus> genericResults = new GenericResult<BookingStatus>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BookingStatus.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Booking status has been added successfully.";
                            genericResults.data = results;
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {               
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public async Task<GenericResult<BookingStatus>> Delete(int id)
        {
            GenericResult<BookingStatus> genericResults = new GenericResult<BookingStatus>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.BookingStatus.GetById(id);
                    if (data != null)
                    {
                        var results = this.BookingStatus.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Booking status has been deleted successfully.";
                                genericResults.data = results;
                            }
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public async Task<GenericResult<BookingStatus>> Get(int id)
        {
            GenericResult<BookingStatus> genericResults = new GenericResult<BookingStatus>();
            try
            {
                var results = await this.BookingStatus.GetById(id);
                genericResults.status = true;
                genericResults.message = "Booking status's record has been found successfully.";
                genericResults.data = results;

                return genericResults;
            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public IQueryable<BookingStatus> GetAll(Expression<Func<BookingStatus, bool>>? filter = null, Func<IQueryable<BookingStatus>, IOrderedQueryable<BookingStatus>>? orderBy = null)
        {        

            try
            {
               return this.BookingStatus.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<BookingStatus>> Update(BookingStatus data)
        {
            GenericResult<BookingStatus> genericResults = new GenericResult<BookingStatus>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BookingStatus.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Booking status has been updated successfully.";
                            genericResults.data = results;
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }
    }
}
