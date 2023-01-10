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
    public class PetBloodScreenDetailsService : IPetBloodScreenDetailsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetBloodScreenDetailsRepository PetBloodScreenDetails;
        public PetBloodScreenDetailsService(
            AlefahDbContext alefahDb, 
            IPetBloodScreenDetailsRepository PetBloodScreenDetails
            )
        {
            this.alefahDb = alefahDb;
            this.PetBloodScreenDetails = PetBloodScreenDetails;
        }
        public async Task<GenericResult<PetBloodScreenDetails>> Add(PetBloodScreenDetails data)
        {
            GenericResult<PetBloodScreenDetails> genericResults = new GenericResult<PetBloodScreenDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodScreenDetails.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Membership category has been added successfully.";
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

        public async Task<GenericResult<PetBloodScreenDetails>> Delete(int id)
        {
            GenericResult<PetBloodScreenDetails> genericResults = new GenericResult<PetBloodScreenDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetBloodScreenDetails.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetBloodScreenDetails.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Membership category has been deleted successfully.";
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

        public async Task<GenericResult<PetBloodScreenDetails>> Get(int id)
        {
            GenericResult<PetBloodScreenDetails> genericResults = new GenericResult<PetBloodScreenDetails>();
            try
            {
                var results = await this.PetBloodScreenDetails.GetById(id);
                genericResults.status = true;
                genericResults.message = "Membership category's record has been found successfully.";
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

        public IQueryable<PetBloodScreenDetails> GetAll(Expression<Func<PetBloodScreenDetails, bool>>? filter = null, Func<IQueryable<PetBloodScreenDetails>, IOrderedQueryable<PetBloodScreenDetails>>? orderBy = null)
        {
            try
            {
                return this.PetBloodScreenDetails.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetBloodScreenDetails>> Update(PetBloodScreenDetails data)
        {
            GenericResult<PetBloodScreenDetails> genericResults = new GenericResult<PetBloodScreenDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodScreenDetails.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Membership category has been updated successfully.";
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
