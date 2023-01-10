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
    public class CustomersAddressLinesService : ICustomersAddressLinesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly ICustomersAddressLinesRepository CustomersAddressLines;
        public CustomersAddressLinesService(
            AlefahDbContext alefahDb, 
            ICustomersAddressLinesRepository CustomersAddressLines
            )
        {
            this.alefahDb = alefahDb;
            this.CustomersAddressLines = CustomersAddressLines;
        }
        public async Task<GenericResult<viewCustomerAddressLines>> Add(CustomersAddressLines data)
        {
            GenericResult<viewCustomerAddressLines> genericResults = new GenericResult<viewCustomerAddressLines>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CustomersAddressLines.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer address has been added successfully.";
                            genericResults.data = await this.CustomersAddressLines.GetAllCustomersAddressLines(x=> x.AddressID  == results.AddressID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<CustomersAddressLines>> Delete(int id)
        {
            GenericResult<CustomersAddressLines> genericResults = new GenericResult<CustomersAddressLines>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.CustomersAddressLines.GetById(id);
                    if (data != null)
                    {
                        var results = this.CustomersAddressLines.Delete(data);

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

        public async Task<GenericResult<CustomersAddressLines>> Get(int id)
        {
            GenericResult<CustomersAddressLines> genericResults = new GenericResult<CustomersAddressLines>();
            try
            {
                var results = await this.CustomersAddressLines.GetById(id);
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

        public IQueryable<viewCustomerAddressLines> GetAll(Expression<Func<viewCustomerAddressLines, bool>>? filter = null, Func<IQueryable<viewCustomerAddressLines>, IOrderedQueryable<viewCustomerAddressLines>>? orderBy = null)
        {
            try
            {
               return this.CustomersAddressLines.GetAllCustomersAddressLines(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewCustomerAddressLines>> Update(CustomersAddressLines data)
        {
            GenericResult<viewCustomerAddressLines> genericResults = new GenericResult<viewCustomerAddressLines>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CustomersAddressLines.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customers address has been updated successfully.";
                            genericResults.data = await this.CustomersAddressLines.GetAllCustomersAddressLines(x => x.AddressID == results.AddressID).FirstOrDefaultAsync(); ;
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
