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
    public class BranchService : IBranchService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IBranchRepository Branch;
        public BranchService(
            AlefahDbContext alefahDb,
            IBranchRepository Branch
            )
        {
            this.alefahDb = alefahDb;
            this.Branch = Branch;
        }
        public async Task<GenericResult<Branch>> Add(Branch data)
        {
            GenericResult<Branch> genericResults = new GenericResult<Branch>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Branch.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Branch has been added successfully.";
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

        public async Task<GenericResult<Branch>> Delete(int id)
        {
            GenericResult<Branch> genericResults = new GenericResult<Branch>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Branch.GetById(id);
                    if (data != null)
                    {
                        var results = this.Branch.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Branch has been deleted successfully.";
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

        public async Task<GenericResult<Branch>> Get(int id)
        {
            GenericResult<Branch> genericResults = new GenericResult<Branch>();
            try
            {
                var results = await this.Branch.GetById(id);
                genericResults.status = true;
                genericResults.message = "Branch's record has been found successfully.";
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

        public IQueryable<Branch> GetAll(Expression<Func<Branch, bool>>? filter = null, Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy = null)
        {
            try
            {
                return this.Branch.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<Branch>> Update(Branch data)
        {
            GenericResult<Branch> genericResults = new GenericResult<Branch>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Branch.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Branch has been updated successfully.";
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
