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
    public class PetSubSpeciesService : IPetSubSpeciesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetSubSpeciesRepository PetSubSpecies;
        public PetSubSpeciesService(
            AlefahDbContext alefahDb, 
            IPetSubSpeciesRepository PetSubSpecies
            )
        {
            this.alefahDb = alefahDb;
            this.PetSubSpecies = PetSubSpecies;
        }
        public async Task<GenericResult<PetSubSpecies>> Add(PetSubSpecies data)
        {
            GenericResult<PetSubSpecies> genericResults = new GenericResult<PetSubSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSubSpecies.Add(data);

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

        public async Task<GenericResult<PetSubSpecies>> Delete(int id)
        {
            GenericResult<PetSubSpecies> genericResults = new GenericResult<PetSubSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetSubSpecies.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetSubSpecies.Delete(data);

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

        public async Task<GenericResult<PetSubSpecies>> Get(int id)
        {
            GenericResult<PetSubSpecies> genericResults = new GenericResult<PetSubSpecies>();
            try
            {
                var results = await this.PetSubSpecies.GetById(id);
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

        public IQueryable<PetSubSpecies> GetAll(Expression<Func<PetSubSpecies, bool>>? filter = null, Func<IQueryable<PetSubSpecies>, IOrderedQueryable<PetSubSpecies>>? orderBy = null)
        {
            try
            {
                return this.PetSubSpecies.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetSubSpecies>> Update(PetSubSpecies data)
        {
            GenericResult<PetSubSpecies> genericResults = new GenericResult<PetSubSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSubSpecies.Update(data);

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
