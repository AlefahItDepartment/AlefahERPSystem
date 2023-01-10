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
    public class CultureCodesService : ICultureCodesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly ICultureCodesRepository CultureCodes;
        public CultureCodesService(
            AlefahDbContext alefahDb, 
            ICultureCodesRepository CultureCodes
            )
        {
            this.alefahDb = alefahDb;
            this.CultureCodes = CultureCodes;
        }
        public async Task<GenericResult<CultureCodes>> Add(CultureCodes data)
        {
            GenericResult<CultureCodes> genericResults = new GenericResult<CultureCodes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CultureCodes.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "CultureCodes has been added successfully.";
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

        public async Task<GenericResult<CultureCodes>> Delete(int id)
        {
            GenericResult<CultureCodes> genericResults = new GenericResult<CultureCodes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.CultureCodes.GetById(id);
                    if (data != null)
                    {
                        var results = this.CultureCodes.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "CultureCodes has been deleted successfully.";
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

        public async Task<GenericResult<CultureCodes>> Get(int id)
        {
            GenericResult<CultureCodes> genericResults = new GenericResult<CultureCodes>();
            try
            {
                var results = await this.CultureCodes.GetById(id);
                genericResults.status = true;
                genericResults.message = "CultureCodes's record has been found successfully.";
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

        public IQueryable<CultureCodes> GetAll(Expression<Func<CultureCodes, bool>>? filter = null, Func<IQueryable<CultureCodes>, IOrderedQueryable<CultureCodes>>? orderBy = null)
        {
         
            try
            {
              return this.CultureCodes.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<CultureCodes>> Update(CultureCodes data)
        {
            GenericResult<CultureCodes> genericResults = new GenericResult<CultureCodes>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.CultureCodes.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "CultureCodes has been updated successfully.";
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
