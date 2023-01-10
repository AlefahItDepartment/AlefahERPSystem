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
    public class PetExamineTypesService : IPetExamineTypesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetExamineTypesRepository PetExamineTypes;
        public PetExamineTypesService(
            AlefahDbContext alefahDb, 
            IPetExamineTypesRepository PetExamineTypes
            )
        {
            this.alefahDb = alefahDb;
            this.PetExamineTypes = PetExamineTypes;
        }
        public async Task<GenericResult<PetExamineTypes>> Add(PetExamineTypes data)
        {
            GenericResult<PetExamineTypes> genericResults = new GenericResult<PetExamineTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetExamineTypes.Add(data);

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

        public async Task<GenericResult<PetExamineTypes>> Delete(int id)
        {
            GenericResult<PetExamineTypes> genericResults = new GenericResult<PetExamineTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetExamineTypes.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetExamineTypes.Delete(data);

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

        public async Task<GenericResult<PetExamineTypes>> Get(int id)
        {
            GenericResult<PetExamineTypes> genericResults = new GenericResult<PetExamineTypes>();
            try
            {
                var results = await this.PetExamineTypes.GetById(id);
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

        public IQueryable<PetExamineTypes> GetAll(Expression<Func<PetExamineTypes, bool>>? filter = null, Func<IQueryable<PetExamineTypes>, IOrderedQueryable<PetExamineTypes>>? orderBy = null)
        {
            try
            {
                return this.PetExamineTypes.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetExamineTypes>> Update(PetExamineTypes data)
        {
            GenericResult<PetExamineTypes> genericResults = new GenericResult<PetExamineTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetExamineTypes.Update(data);

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
