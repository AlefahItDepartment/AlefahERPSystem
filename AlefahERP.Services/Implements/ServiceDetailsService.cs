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
    public class ServiceDetailsService : IServiceDetailsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IServiceDetailsRepository ServiceDetails;
        public ServiceDetailsService(
            AlefahDbContext alefahDb, 
            IServiceDetailsRepository ServiceDetails
            )
        {
            this.alefahDb = alefahDb;
            this.ServiceDetails = ServiceDetails;
        }
        public async Task<GenericResult<viewServiceDetails>> Add(ServiceDetails data)
        {
            GenericResult<viewServiceDetails> genericResults = new GenericResult<viewServiceDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.ServiceDetails.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer address has been added successfully.";
                            genericResults.data = await this.ServiceDetails.GetViewServiceDetails(x=> x.ServiceDetailID  == results.ServiceDetailID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<ServiceDetails>> Delete(int id)
        {
            GenericResult<ServiceDetails> genericResults = new GenericResult<ServiceDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.ServiceDetails.GetById(id);
                    if (data != null)
                    {
                        var results = this.ServiceDetails.Delete(data);

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

        public async Task<GenericResult<ServiceDetails>> Get(int id)
        {
            GenericResult<ServiceDetails> genericResults = new GenericResult<ServiceDetails>();
            try
            {
                var results = await this.ServiceDetails.GetById(id);
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

        public IQueryable<viewServiceDetails> GetAll(Expression<Func<viewServiceDetails, bool>>? filter = null, Func<IQueryable<viewServiceDetails>, IOrderedQueryable<viewServiceDetails>>? orderBy = null)
        {
            try
            {
               return this.ServiceDetails.GetViewServiceDetails(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewServiceDetails>> Update(ServiceDetails data)
        {
            GenericResult<viewServiceDetails> genericResults = new GenericResult<viewServiceDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.ServiceDetails.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customers address has been updated successfully.";
                            genericResults.data = await this.ServiceDetails.GetViewServiceDetails(x => x.ServiceDetailID == results.ServiceDetailID).FirstOrDefaultAsync(); ;
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
