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
    public class UsersService : IUsersService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IUsersRepository Users;
        public UsersService(
            AlefahDbContext alefahDb, 
            IUsersRepository Users
            )
        {
            this.alefahDb = alefahDb;
            this.Users = Users;
        }
        public async Task<GenericResult<viewUsers>> Add(Users data)
        {
            GenericResult<viewUsers> genericResults = new GenericResult<viewUsers>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Users.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer address has been added successfully.";
                            genericResults.data = await this.Users.GetAllUsers(x=> x.UserID  == results.UserID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<Users>> Delete(int id)
        {
            GenericResult<Users> genericResults = new GenericResult<Users>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Users.GetById(id);
                    if (data != null)
                    {
                        var results = this.Users.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Customer address has been deleted successfully.";
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

        public async Task<GenericResult<Users>> Get(int id)
        {
            GenericResult<Users> genericResults = new GenericResult<Users>();
            try
            {
                var results = await this.Users.GetById(id);
                genericResults.status = true;
                genericResults.message = "Customer address's record has been found successfully.";
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

        public IQueryable<viewUsers> GetAll(Expression<Func<viewUsers, bool>>? filter = null, Func<IQueryable<viewUsers>, IOrderedQueryable<viewUsers>>? orderBy = null)
        {
            try
            {
                return this.Users.GetAllUsers(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<viewUsers>> Update(Users data)
        {
            GenericResult<viewUsers> genericResults = new GenericResult<viewUsers>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Users.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customers address has been updated successfully.";
                            genericResults.data = await this.Users.GetAllUsers(x => x.UserID == results.UserID).FirstOrDefaultAsync(); ;
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
