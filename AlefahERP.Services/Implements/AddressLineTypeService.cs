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
    public class AddressLineTypeService : IAddressLineTypeService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IAddressLineTypeRepository addressLineType;
        public AddressLineTypeService(
            AlefahDbContext alefahDb, 
            IAddressLineTypeRepository addressLineType
            )
        {
            this.alefahDb = alefahDb;
            this.addressLineType = addressLineType;
        }
        public async Task<GenericResult<AddressLineType>> Add(AddressLineType data)
        {
            GenericResult<AddressLineType> genericResults = new GenericResult<AddressLineType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.addressLineType.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Address line has been added successfully.";
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

        public async Task<GenericResult<AddressLineType>> Delete(int id)
        {
            GenericResult<AddressLineType> genericResults = new GenericResult<AddressLineType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.addressLineType.GetById(id);
                    if (data != null)
                    {
                        var results = this.addressLineType.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Address line has been deleted successfully.";
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

        public async Task<GenericResult<AddressLineType>> Get(int id)
        {
            GenericResult<AddressLineType> genericResults = new GenericResult<AddressLineType>();
            try
            {
                var results = await this.addressLineType.GetById(id);
                genericResults.status = true;
                genericResults.message = "Address line's record has been found successfully.";
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

        public IQueryable<AddressLineType> GetAll(Expression<Func<AddressLineType, bool>>? filter = null, Func<IQueryable<AddressLineType>, IOrderedQueryable<AddressLineType>>? orderBy = null)
        {
          

            try
            {
                return this.addressLineType.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<AddressLineType>> Update(AddressLineType data)
        {
            GenericResult<AddressLineType> genericResults = new GenericResult<AddressLineType>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.addressLineType.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Address line has been updated successfully.";
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
