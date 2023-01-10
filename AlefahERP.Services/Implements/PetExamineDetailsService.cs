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
    public class PetExamineDetailsService : IPetExamineDetailsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetExamineDetailsRepository PetExamineDetails;
        public PetExamineDetailsService(
            AlefahDbContext alefahDb, 
            IPetExamineDetailsRepository PetExamineDetails
            )
        {
            this.alefahDb = alefahDb;
            this.PetExamineDetails = PetExamineDetails;
        }
        public async Task<GenericResult<PetExamineDetails>> Add(PetExamineDetails data)
        {
            GenericResult<PetExamineDetails> genericResults = new GenericResult<PetExamineDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetExamineDetails.Add(data);

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

        public async Task<GenericResult<PetExamineDetails>> Delete(int id)
        {
            GenericResult<PetExamineDetails> genericResults = new GenericResult<PetExamineDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetExamineDetails.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetExamineDetails.Delete(data);

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

        public async Task<GenericResult<PetExamineDetails>> Get(int id)
        {
            GenericResult<PetExamineDetails> genericResults = new GenericResult<PetExamineDetails>();
            try
            {
                var results = await this.PetExamineDetails.GetById(id);
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

        public IQueryable<PetExamineDetails> GetAll(Expression<Func<PetExamineDetails, bool>>? filter = null, Func<IQueryable<PetExamineDetails>, IOrderedQueryable<PetExamineDetails>>? orderBy = null)
        {
            try
            {
               return this.PetExamineDetails.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetExamineDetails>> Update(PetExamineDetails data)
        {
            GenericResult<PetExamineDetails> genericResults = new GenericResult<PetExamineDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetExamineDetails.Update(data);

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
