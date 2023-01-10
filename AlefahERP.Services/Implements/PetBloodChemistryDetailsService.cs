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
    public class PetBloodChemistryDetailsService : IPetBloodChemistryDetailsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetBloodChemistryDetailsRepository PetBloodChemistryDetails;
        public PetBloodChemistryDetailsService(
            AlefahDbContext alefahDb, 
            IPetBloodChemistryDetailsRepository PetBloodChemistryDetails
            )
        {
            this.alefahDb = alefahDb;
            this.PetBloodChemistryDetails = PetBloodChemistryDetails;
        }
        public async Task<GenericResult<PetBloodChemistryDetails>> Add(PetBloodChemistryDetails data)
        {
            GenericResult<PetBloodChemistryDetails> genericResults = new GenericResult<PetBloodChemistryDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodChemistryDetails.Add(data);

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

        public async Task<GenericResult<PetBloodChemistryDetails>> Delete(int id)
        {
            GenericResult<PetBloodChemistryDetails> genericResults = new GenericResult<PetBloodChemistryDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetBloodChemistryDetails.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetBloodChemistryDetails.Delete(data);

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

        public async Task<GenericResult<PetBloodChemistryDetails>> Get(int id)
        {
            GenericResult<PetBloodChemistryDetails> genericResults = new GenericResult<PetBloodChemistryDetails>();
            try
            {
                var results = await this.PetBloodChemistryDetails.GetById(id);
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

        public IQueryable<PetBloodChemistryDetails> GetAll(Expression<Func<PetBloodChemistryDetails, bool>>? filter = null, Func<IQueryable<PetBloodChemistryDetails>, IOrderedQueryable<PetBloodChemistryDetails>>? orderBy = null)
        {
            try
            {
                return  this.PetBloodChemistryDetails.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetBloodChemistryDetails>> Update(PetBloodChemistryDetails data)
        {
            GenericResult<PetBloodChemistryDetails> genericResults = new GenericResult<PetBloodChemistryDetails>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodChemistryDetails.Update(data);

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
