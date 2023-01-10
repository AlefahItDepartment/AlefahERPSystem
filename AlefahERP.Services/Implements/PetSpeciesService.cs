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
    public class PetSpeciesService : IPetSpeciesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetSpeciesRepository PetSpecies;
        public PetSpeciesService(
            AlefahDbContext alefahDb, 
            IPetSpeciesRepository PetSpecies
            )
        {
            this.alefahDb = alefahDb;
            this.PetSpecies = PetSpecies;
        }
        public async Task<GenericResult<PetSpecies>> Add(PetSpecies data)
        {
            GenericResult<PetSpecies> genericResults = new GenericResult<PetSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSpecies.Add(data);

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

        public async Task<GenericResult<PetSpecies>> Delete(int id)
        {
            GenericResult<PetSpecies> genericResults = new GenericResult<PetSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetSpecies.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetSpecies.Delete(data);

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

        public async Task<GenericResult<PetSpecies>> Get(int id)
        {
            GenericResult<PetSpecies> genericResults = new GenericResult<PetSpecies>();
            try
            {
                var results = await this.PetSpecies.GetById(id);
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

        public IQueryable<PetSpecies> GetAll(Expression<Func<PetSpecies, bool>>? filter = null, Func<IQueryable<PetSpecies>, IOrderedQueryable<PetSpecies>>? orderBy = null)
        {
            try
            {
                return this.PetSpecies.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetSpecies>> Update(PetSpecies data)
        {
            GenericResult<PetSpecies> genericResults = new GenericResult<PetSpecies>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetSpecies.Update(data);

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
