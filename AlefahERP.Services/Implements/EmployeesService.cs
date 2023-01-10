using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using AlefahERP.Services.RequestModels;
using AlefahERP.Services.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Services.Implements
{
    public class EmployeesService : IEmployeesService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IEmployeesRepository Employees;
        private readonly IUsersRepository users;
        private readonly IUserRoleRepository userRole;
        public EmployeesService(
            AlefahDbContext alefahDb,
            IEmployeesRepository Employees,
            IUsersRepository users,
            IUserRoleRepository userRole
            )
        {
            this.alefahDb = alefahDb;
            this.Employees = Employees;
            this.users = users;
            this.userRole = userRole;
        }
        public async Task<GenericResult<EmployeeResponseModel>> Add(EmployeeRequestModel data)
        {
            GenericResult<EmployeeResponseModel> genericResults = new GenericResult<EmployeeResponseModel>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    Users? _user = null;
                    if (data.User != null)
                    {
                        if (data.UserRole != null)
                            data.User.UserRoleID = data.UserRole.UserRoleID;

                        data.User.CreatedDate = DateTime.Now;

                        _user = this.users.Add(data.User);
                    }

                    if (_user != null)
                        data.Employee.UserID = _user.UserID;

                    data.Employee.CreatedDate = DateTime.Now;


                    var results = this.Employees.Add(data.Employee);

                    if (results != null)
                    {

                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Employee has been added successfully.";
                            genericResults.data = new EmployeeResponseModel();
                            genericResults.data.Employee = new viewEmployees();
                            genericResults.data.Employee = await this.Employees.GetAllEmployees(x => x.EmployeeID == results.EmployeeID).FirstOrDefaultAsync();
                            genericResults.data.User = new viewUsers();
                            genericResults.data.User = await this.users.GetAllUsers(x => x.UserID == results.UserID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<Employees>> Delete(int id)
        {
            GenericResult<Employees> genericResults = new GenericResult<Employees>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Employees.GetById(id);
                    if (data != null)
                    {

                        this.users.Delete(await this.users.GetById(data.UserID));

                        var results = this.Employees.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Employee has been deleted successfully.";
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

        public async Task<GenericResult<Employees>> Get(int id)
        {
            GenericResult<Employees> genericResults = new GenericResult<Employees>();
            try
            {
                var results = await this.Employees.GetById(id);
                genericResults.status = true;
                genericResults.message = "Employees's record has been found successfully.";
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

        public IQueryable<viewEmployees> GetAll(Expression<Func<viewEmployees, bool>>? filter = null, Func<IQueryable<viewEmployees>, IOrderedQueryable<viewEmployees>>? orderBy = null)
        {
            try
            {
               return this.Employees.GetAllEmployees(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<EmployeeResponseModel>> Update(EmployeeRequestModel data)
        {
            GenericResult<EmployeeResponseModel> genericResults = new GenericResult<EmployeeResponseModel>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var results = this.Employees.Update(data.Employee);

                    if (results != null)
                    {

                        if (data.User != null)
                        {
                            if (data.UserRole != null)
                                data.User.UserRoleID = data.UserRole.UserRoleID;

                            data.User.UpdatedDate = DateTime.Now;
                            this.users.Update(data.User);
                        }


                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Employee has been updated successfully.";
                            genericResults.data = new EmployeeResponseModel();
                            genericResults.data.Employee = new viewEmployees();
                            genericResults.data.Employee = await this.Employees.GetAllEmployees(x => x.EmployeeID == results.EmployeeID).FirstOrDefaultAsync();
                            genericResults.data.User = new viewUsers();
                            genericResults.data.User = await this.users.GetAllUsers(x => x.UserID == results.UserID).FirstOrDefaultAsync();
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
