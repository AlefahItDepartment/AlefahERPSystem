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
    public class PetBreedsService : IPetBreedsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetBreedsRepository PetBreeds;
        public PetBreedsService(
            AlefahDbContext alefahDb, 
            IPetBreedsRepository PetBreeds
            )
        {
            this.alefahDb = alefahDb;
            this.PetBreeds = PetBreeds;
        }
        public async Task<GenericResult<PetBreeds>> Add(PetBreeds data)
        {
            GenericResult<PetBreeds> genericResults = new GenericResult<PetBreeds>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBreeds.Add(data);

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

        public async Task<GenericResult<PetBreeds>> Delete(int id)
        {
            GenericResult<PetBreeds> genericResults = new GenericResult<PetBreeds>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetBreeds.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetBreeds.Delete(data);

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

        public async Task<GenericResult<PetBreeds>> Get(int id)
        {
            GenericResult<PetBreeds> genericResults = new GenericResult<PetBreeds>();
            try
            {
                var results = await this.PetBreeds.GetById(id);
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

        public IQueryable<PetBreeds> GetAll(Expression<Func<PetBreeds, bool>>? filter = null, Func<IQueryable<PetBreeds>, IOrderedQueryable<PetBreeds>>? orderBy = null)
        {
            try
            {
                return this.PetBreeds.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetBreeds>> Update(PetBreeds data)
        {
            GenericResult<PetBreeds> genericResults = new GenericResult<PetBreeds>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetBreeds.Update(data);

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
