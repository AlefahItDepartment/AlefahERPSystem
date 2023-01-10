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
    public class PetSizesService : IPetSizesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetSizesRepository PetSizes;
        public PetSizesService(
            AlefahDbContext alefahDb, 
            IPetSizesRepository PetSizes
            )
        {
            this.alefahDb = alefahDb;
            this.PetSizes = PetSizes;
        }
        public async Task<GenericResult<PetSizes>> Add(PetSizes data)
        {
            GenericResult<PetSizes> genericResults = new GenericResult<PetSizes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSizes.Add(data);

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

        public async Task<GenericResult<PetSizes>> Delete(int id)
        {
            GenericResult<PetSizes> genericResults = new GenericResult<PetSizes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetSizes.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetSizes.Delete(data);

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

        public async Task<GenericResult<PetSizes>> Get(int id)
        {
            GenericResult<PetSizes> genericResults = new GenericResult<PetSizes>();
            try
            {
                var results = await this.PetSizes.GetById(id);
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

        public IQueryable<PetSizes> GetAll(Expression<Func<PetSizes, bool>>? filter = null, Func<IQueryable<PetSizes>, IOrderedQueryable<PetSizes>>? orderBy = null)
        {
            try
            {
               return this.PetSizes.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetSizes>> Update(PetSizes data)
        {
            GenericResult<PetSizes> genericResults = new GenericResult<PetSizes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSizes.Update(data);

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
