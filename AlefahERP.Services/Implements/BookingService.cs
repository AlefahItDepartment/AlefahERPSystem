using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using AlefahERP.Services.RequestModels;
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
    public class BookingService : IBookingService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IBookingHeadRepository Booking;
        private readonly IBookingDetailsRepository BookingDetails;
        public BookingService(
            AlefahDbContext alefahDb,
            IBookingHeadRepository Booking,
            IBookingDetailsRepository BookingDetails
            )
        {
            this.alefahDb = alefahDb;
            this.Booking = Booking;
            this.BookingDetails = BookingDetails;
        }
        public async Task<GenericResult<viewBookingHead>> Add(BookingRequestModel data)
        {
            GenericResult<viewBookingHead> genericResults = new GenericResult<viewBookingHead>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    data.Booking.BookingNumber = await this.Booking.BookingNumber(data.Booking.BranchID);
                    data.Booking.BookingDate = DateTime.Now;

                    var results = this.Booking.Add(data.Booking);

                    if (results != null)
                    {

                        if (data.BookingDetails != null && data.BookingDetails.Count > 0)
                        {
                            foreach (var item in data.BookingDetails)
                            {
                                item.BookingHeadID = results.BookingHeadID;
                                this.BookingDetails.Add(item);
                            }
                        }


                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Booking appointment has been added successfully.";
                            genericResults.data = await this.Booking.GetAllBookingHead(x => x.BookingHeadID == results.BookingHeadID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<viewBookingHead>> Delete(int id)
        {
            GenericResult<viewBookingHead> genericResults = new GenericResult<viewBookingHead>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Booking.GetById(id);
                    if (data != null)
                    {

                        var bookingDetails = await this.BookingDetails.GetAll(x => x.BookingHeadID == data.BookingHeadID).ToListAsync();

                        if (bookingDetails != null && bookingDetails.Count > 0)
                        {
                            foreach (var item in bookingDetails)
                            {
                                this.BookingDetails.Delete(item);
                            }
                        }

                        var results = this.Booking.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Booking appointment has been deleted successfully.";
                                genericResults.data = await this.Booking.GetAllBookingHead(x => x.BookingHeadID == results.BookingHeadID).FirstOrDefaultAsync(); ;
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

        public async Task<GenericResult<BookingHead>> Get(int id)
        {
            GenericResult<BookingHead> genericResults = new GenericResult<BookingHead>();
            try
            {
                var results = await this.Booking.GetById(id);
                genericResults.status = true;
                genericResults.message = "Booking appointment's record has been found successfully.";
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

        public IQueryable<viewBookingHead> GetAll(Expression<Func<viewBookingHead, bool>>? filter = null, Func<IQueryable<viewBookingHead>, IOrderedQueryable<viewBookingHead>>? orderBy = null)
        {


            try
            {
                return this.Booking.GetAllBookingHead(filter, orderBy);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewBookingHead>> Update(BookingRequestModel data)
        {
            GenericResult<viewBookingHead> genericResults = new GenericResult<viewBookingHead>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Booking.Update(data.Booking);

                    if (results != null)
                    {

                        var bookingDetails = await this.BookingDetails.GetAll(x => x.BookingHeadID == results.BookingHeadID).ToListAsync();

                        if (bookingDetails != null && bookingDetails.Count > 0)
                        {
                            foreach (var item in bookingDetails)
                            {
                                this.BookingDetails.Delete(item);
                            }
                        }

                        if (data.BookingDetails != null && data.BookingDetails.Count > 0)
                        {
                            foreach (var item in data.BookingDetails)
                            {
                                this.BookingDetails.Add(item);
                            }
                        }

                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Booking appointment has been updated successfully.";
                            genericResults.data = await this.Booking.GetAllBookingHead(x => x.BookingHeadID == results.BookingHeadID).FirstOrDefaultAsync();
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
