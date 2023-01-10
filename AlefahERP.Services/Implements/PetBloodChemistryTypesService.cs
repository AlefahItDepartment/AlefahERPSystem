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
    public class PetBloodChemistryTypesService : IPetBloodChemistryTypesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetBloodChemistryTypesRepository PetBloodChemistryTypes;
        public PetBloodChemistryTypesService(
            AlefahDbContext alefahDb, 
            IPetBloodChemistryTypesRepository PetBloodChemistryTypes
            )
        {
            this.alefahDb = alefahDb;
            this.PetBloodChemistryTypes = PetBloodChemistryTypes;
        }
        public async Task<GenericResult<PetBloodChemistryTypes>> Add(PetBloodChemistryTypes data)
        {
            GenericResult<PetBloodChemistryTypes> genericResults = new GenericResult<PetBloodChemistryTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodChemistryTypes.Add(data);

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

        public async Task<GenericResult<PetBloodChemistryTypes>> Delete(int id)
        {
            GenericResult<PetBloodChemistryTypes> genericResults = new GenericResult<PetBloodChemistryTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetBloodChemistryTypes.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetBloodChemistryTypes.Delete(data);

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

        public async Task<GenericResult<PetBloodChemistryTypes>> Get(int id)
        {
            GenericResult<PetBloodChemistryTypes> genericResults = new GenericResult<PetBloodChemistryTypes>();
            try
            {
                var results = await this.PetBloodChemistryTypes.GetById(id);
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

        public IQueryable<PetBloodChemistryTypes> GetAll(Expression<Func<PetBloodChemistryTypes, bool>>? filter = null, Func<IQueryable<PetBloodChemistryTypes>, IOrderedQueryable<PetBloodChemistryTypes>>? orderBy = null)
        {
            try
            {
               return this.PetBloodChemistryTypes.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetBloodChemistryTypes>> Update(PetBloodChemistryTypes data)
        {
            GenericResult<PetBloodChemistryTypes> genericResults = new GenericResult<PetBloodChemistryTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodChemistryTypes.Update(data);

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
