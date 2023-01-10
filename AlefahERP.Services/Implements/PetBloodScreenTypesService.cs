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
    public class PetBloodScreenTypesService : IPetBloodScreenTypesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetBloodScreenTypesRepository PetBloodScreenTypes;
        public PetBloodScreenTypesService(
            AlefahDbContext alefahDb, 
            IPetBloodScreenTypesRepository PetBloodScreenTypes
            )
        {
            this.alefahDb = alefahDb;
            this.PetBloodScreenTypes = PetBloodScreenTypes;
        }
        public async Task<GenericResult<PetBloodScreenTypes>> Add(PetBloodScreenTypes data)
        {
            GenericResult<PetBloodScreenTypes> genericResults = new GenericResult<PetBloodScreenTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodScreenTypes.Add(data);

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

        public async Task<GenericResult<PetBloodScreenTypes>> Delete(int id)
        {
            GenericResult<PetBloodScreenTypes> genericResults = new GenericResult<PetBloodScreenTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetBloodScreenTypes.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetBloodScreenTypes.Delete(data);

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

        public async Task<GenericResult<PetBloodScreenTypes>> Get(int id)
        {
            GenericResult<PetBloodScreenTypes> genericResults = new GenericResult<PetBloodScreenTypes>();
            try
            {
                var results = await this.PetBloodScreenTypes.GetById(id);
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

        public IQueryable<PetBloodScreenTypes> GetAll(Expression<Func<PetBloodScreenTypes, bool>>? filter = null, Func<IQueryable<PetBloodScreenTypes>, IOrderedQueryable<PetBloodScreenTypes>>? orderBy = null)
        {
            try
            {
                return this.PetBloodScreenTypes.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetBloodScreenTypes>> Update(PetBloodScreenTypes data)
        {
            GenericResult<PetBloodScreenTypes> genericResults = new GenericResult<PetBloodScreenTypes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBloodScreenTypes.Update(data);

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
