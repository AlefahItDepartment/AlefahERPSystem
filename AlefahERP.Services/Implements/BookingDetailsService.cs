using AlefahERP.Bookings.Interfaces;
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
    public class BookingDetailsService : IBookingDetailsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IBookingDetailsRepository BookingDetails;
        public BookingDetailsService(
            AlefahDbContext alefahDb, 
            IBookingDetailsRepository BookingDetails
            )
        {
            this.alefahDb = alefahDb;
            this.BookingDetails = BookingDetails;
        }
        public async Task<GenericResult<viewBookingDetails>> Add(BookingDetails data)
        {
            GenericResult<viewBookingDetails> genericResults = new GenericResult<viewBookingDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BookingDetails.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer address has been added successfully.";
                            genericResults.data = await this.BookingDetails.GetAllBookingDetails(x=> x.ServiceDetailID  == results.ServiceDetailID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<BookingDetails>> Delete(int id)
        {
            GenericResult<BookingDetails> genericResults = new GenericResult<BookingDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.BookingDetails.GetById(id);
                    if (data != null)
                    {
                        var results = this.BookingDetails.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Customer address has been deleted successfully.";
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

        public async Task<GenericResult<BookingDetails>> Get(int id)
        {
            GenericResult<BookingDetails> genericResults = new GenericResult<BookingDetails>();
            try
            {
                var results = await this.BookingDetails.GetById(id);
                genericResults.status = true;
                genericResults.message = "Customer address's record has been found successfully.";
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

        public IQueryable<viewBookingDetails> GetAll(Expression<Func<viewBookingDetails, bool>>? filter = null, Func<IQueryable<viewBookingDetails>, IOrderedQueryable<viewBookingDetails>>? orderBy = null)
        {    

            try
            {
                return  this.BookingDetails.GetAllBookingDetails(filter, orderBy);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewBookingDetails>> Update(BookingDetails data)
        {
            GenericResult<viewBookingDetails> genericResults = new GenericResult<viewBookingDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BookingDetails.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customers address has been updated successfully.";
                            genericResults.data = await this.BookingDetails.GetAllBookingDetails(x=> x.BookingDetailID == results.BookingDetailID).FirstOrDefaultAsync() ;
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
