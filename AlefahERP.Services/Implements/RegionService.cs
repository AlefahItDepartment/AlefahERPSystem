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
    public class RegionService : IRegionService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IRegionRepository Region;
        public RegionService(
            AlefahDbContext alefahDb, 
            IRegionRepository Region
            )
        {
            this.alefahDb = alefahDb;
            this.Region = Region;
        }
        public async Task<GenericResult<Region>> Add(Region data)
        {
            GenericResult<Region> genericResults = new GenericResult<Region>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Region.Add(data);

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

        public async Task<GenericResult<Region>> Delete(int id)
        {
            GenericResult<Region> genericResults = new GenericResult<Region>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Region.GetById(id);
                    if (data != null)
                    {
                        var results = this.Region.Delete(data);

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

        public async Task<GenericResult<Region>> Get(int id)
        {
            GenericResult<Region> genericResults = new GenericResult<Region>();
            try
            {
                var results = await this.Region.GetById(id);
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

        public IQueryable<Region> GetAll(Expression<Func<Region, bool>>? filter = null, Func<IQueryable<Region>, IOrderedQueryable<Region>>? orderBy = null)
        {
            try
            {
                return this.Region.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<Region>> Update(Region data)
        {
            GenericResult<Region> genericResults = new GenericResult<Region>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Region.Update(data);

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
