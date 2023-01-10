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
    public class MembershipCategoryService : IMembershipCategoryService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IMembershipCategoryRepository MembershipCategory;
        public MembershipCategoryService(
            AlefahDbContext alefahDb, 
            IMembershipCategoryRepository MembershipCategory
            )
        {
            this.alefahDb = alefahDb;
            this.MembershipCategory = MembershipCategory;
        }
        public async Task<GenericResult<MembershipCategory>> Add(MembershipCategory data)
        {
            GenericResult<MembershipCategory> genericResults = new GenericResult<MembershipCategory>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.MembershipCategory.Add(data);

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

        public async Task<GenericResult<MembershipCategory>> Delete(int id)
        {
            GenericResult<MembershipCategory> genericResults = new GenericResult<MembershipCategory>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.MembershipCategory.GetById(id);
                    if (data != null)
                    {
                        var results = this.MembershipCategory.Delete(data);

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

        public async Task<GenericResult<MembershipCategory>> Get(int id)
        {
            GenericResult<MembershipCategory> genericResults = new GenericResult<MembershipCategory>();
            try
            {
                var results = await this.MembershipCategory.GetById(id);
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

        public IQueryable<MembershipCategory> GetAll(Expression<Func<MembershipCategory, bool>>? filter = null, Func<IQueryable<MembershipCategory>, IOrderedQueryable<MembershipCategory>>? orderBy = null)
        {
            try
            {
               return this.MembershipCategory.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<MembershipCategory>> Update(MembershipCategory data)
        {
            GenericResult<MembershipCategory> genericResults = new GenericResult<MembershipCategory>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.MembershipCategory.Update(data);

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
