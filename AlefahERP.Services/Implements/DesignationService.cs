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
    public class DesignationService : IDesignationService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IDesignationRepository Designation;
        public DesignationService(
            AlefahDbContext alefahDb, 
            IDesignationRepository Designation
            )
        {
            this.alefahDb = alefahDb;
            this.Designation = Designation;
        }
        public async Task<GenericResult<Designation>> Add(Designation data)
        {
            GenericResult<Designation> genericResults = new GenericResult<Designation>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Designation.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Designation has been added successfully.";
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

        public async Task<GenericResult<Designation>> Delete(int id)
        {
            GenericResult<Designation> genericResults = new GenericResult<Designation>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Designation.GetById(id);
                    if (data != null)
                    {
                        var results = this.Designation.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Designation has been deleted successfully.";
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

        public async Task<GenericResult<Designation>> Get(int id)
        {
            GenericResult<Designation> genericResults = new GenericResult<Designation>();
            try
            {
                var results = await this.Designation.GetById(id);
                genericResults.status = true;
                genericResults.message = "Designation's record has been found successfully.";
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

        public IQueryable<Designation> GetAll(Expression<Func<Designation, bool>>? filter = null, Func<IQueryable<Designation>, IOrderedQueryable<Designation>>? orderBy = null)
        {
            try
            {
              return  this.Designation.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<Designation>> Update(Designation data)
        {
            GenericResult<Designation> genericResults = new GenericResult<Designation>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Designation.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Designation has been updated successfully.";
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
