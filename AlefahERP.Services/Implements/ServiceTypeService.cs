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
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IServiceTypeRepository ServiceType;
        public ServiceTypeService(
            AlefahDbContext alefahDb, 
            IServiceTypeRepository ServiceType
            )
        {
            this.alefahDb = alefahDb;
            this.ServiceType = ServiceType;
        }
        public async Task<GenericResult<ServiceType>> Add(ServiceType data)
        {
            GenericResult<ServiceType> genericResults = new GenericResult<ServiceType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.ServiceType.Add(data);

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

        public async Task<GenericResult<ServiceType>> Delete(int id)
        {
            GenericResult<ServiceType> genericResults = new GenericResult<ServiceType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.ServiceType.GetById(id);
                    if (data != null)
                    {
                        var results = this.ServiceType.Delete(data);

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

        public async Task<GenericResult<ServiceType>> Get(int id)
        {
            GenericResult<ServiceType> genericResults = new GenericResult<ServiceType>();
            try
            {
                var results = await this.ServiceType.GetById(id);
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

        public IQueryable<ServiceType> GetAll(Expression<Func<ServiceType, bool>>? filter = null, Func<IQueryable<ServiceType>, IOrderedQueryable<ServiceType>>? orderBy = null)
        {
            try
            {
              return this.ServiceType.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<ServiceType>> Update(ServiceType data)
        {
            GenericResult<ServiceType> genericResults = new GenericResult<ServiceType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.ServiceType.Update(data);

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
