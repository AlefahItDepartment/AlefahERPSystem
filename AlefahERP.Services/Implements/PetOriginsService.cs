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
    public class PetOriginsService : IPetOriginsService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IPetOriginsRepository PetOrigins;
        public PetOriginsService(
            AlefahDbContext alefahDb, 
            IPetOriginsRepository PetOrigins
            )
        {
            this.alefahDb = alefahDb;
            this.PetOrigins = PetOrigins;
        }
        public async Task<GenericResult<PetOrigins>> Add(PetOrigins data)
        {
            GenericResult<PetOrigins> genericResults = new GenericResult<PetOrigins>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetOrigins.Add(data);

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

        public async Task<GenericResult<PetOrigins>> Delete(int id)
        {
            GenericResult<PetOrigins> genericResults = new GenericResult<PetOrigins>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.PetOrigins.GetById(id);
                    if (data != null)
                    {
                        var results = this.PetOrigins.Delete(data);

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

        public async Task<GenericResult<PetOrigins>> Get(int id)
        {
            GenericResult<PetOrigins> genericResults = new GenericResult<PetOrigins>();
            try
            {
                var results = await this.PetOrigins.GetById(id);
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

        public IQueryable<PetOrigins> GetAll(Expression<Func<PetOrigins, bool>>? filter = null, Func<IQueryable<PetOrigins>, IOrderedQueryable<PetOrigins>>? orderBy = null)
        {
            try
            {
                return this.PetOrigins.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<PetOrigins>> Update(PetOrigins data)
        {
            GenericResult<PetOrigins> genericResults = new GenericResult<PetOrigins>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.PetOrigins.Update(data);

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
