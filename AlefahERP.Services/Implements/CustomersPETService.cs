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
    public class CustomersPETService : ICustomersPETService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly ICustomersPETRepository CustomersPET;
        public CustomersPETService(
            AlefahDbContext alefahDb, 
            ICustomersPETRepository CustomersPET
            )
        {
            this.alefahDb = alefahDb;
            this.CustomersPET = CustomersPET;
        }
        public async Task<GenericResult<viewCustomersPET>> Add(CustomersPET data)
        {
            GenericResult<viewCustomersPET> genericResults = new GenericResult<viewCustomersPET>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CustomersPET.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer pet has been added successfully.";
                            genericResults.data = await this.CustomersPET.GetAllCustomersPET(x=> x.CustomerPetID == results.CustomerPetID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<CustomersPET>> Delete(int id)
        {
            GenericResult<CustomersPET> genericResults = new GenericResult<CustomersPET>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.CustomersPET.GetById(id);
                    if (data != null)
                    {
                        var results = this.CustomersPET.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Customer pet has been deleted successfully.";
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

        public async Task<GenericResult<CustomersPET>> Get(int id)
        {
            GenericResult<CustomersPET> genericResults = new GenericResult<CustomersPET>();
            try
            {
                var results = await this.CustomersPET.GetById(id);
                genericResults.status = true;
                genericResults.message = "Customer pet's record has been found successfully.";
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

        public IQueryable<viewCustomersPET> GetAll(Expression<Func<viewCustomersPET, bool>>? filter = null, Func<IQueryable<viewCustomersPET>, IOrderedQueryable<viewCustomersPET>>? orderBy = null)
        {
            try
            {
                return this.CustomersPET.GetAllCustomersPET(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewCustomersPET>> Update(CustomersPET data)
        {
            GenericResult<viewCustomersPET> genericResults = new GenericResult<viewCustomersPET>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CustomersPET.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customers pet has been updated successfully.";
                            genericResults.data = await this.CustomersPET.GetAllCustomersPET(x => x.CustomerPetID == results.CustomerPetID).FirstOrDefaultAsync(); ;
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
