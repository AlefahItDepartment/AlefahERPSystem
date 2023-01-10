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
    public class BranchSchedulesService : IBranchSchedulesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IBranchSchedulesRepository BranchSchedules;
        public BranchSchedulesService(
            AlefahDbContext alefahDb,
            IBranchSchedulesRepository BranchSchedules
            )
        {
            this.alefahDb = alefahDb;
            this.BranchSchedules = BranchSchedules;
        }
        public async Task<GenericResult<BranchSchedules>> Add(BranchSchedules data)
        {
            GenericResult<BranchSchedules> genericResults = new GenericResult<BranchSchedules>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BranchSchedules.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "BranchSchedules has been added successfully.";
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

        public async Task<GenericResult<BranchSchedules>> Delete(int id)
        {
            GenericResult<BranchSchedules> genericResults = new GenericResult<BranchSchedules>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.BranchSchedules.GetById(id);
                    if (data != null)
                    {
                        var results = this.BranchSchedules.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "BranchSchedules has been deleted successfully.";
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

        public async Task<GenericResult<BranchSchedules>> Get(int id)
        {
            GenericResult<BranchSchedules> genericResults = new GenericResult<BranchSchedules>();
            try
            {
                var results = await this.BranchSchedules.GetById(id);
                genericResults.status = true;
                genericResults.message = "BranchSchedules's record has been found successfully.";
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

        public IQueryable<BranchSchedules> GetAll(Expression<Func<BranchSchedules, bool>>? filter = null, Func<IQueryable<BranchSchedules>, IOrderedQueryable<BranchSchedules>>? orderBy = null)
        {

            try
            {
                return this.BranchSchedules.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<BranchSchedules>> Update(BranchSchedules data)
        {
            GenericResult<BranchSchedules> genericResults = new GenericResult<BranchSchedules>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.BranchSchedules.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "BranchSchedules has been updated successfully.";
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
