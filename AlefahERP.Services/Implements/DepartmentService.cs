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
    public class DepartmentService : IDepartmentService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IDepartmentRepository Department;
        public DepartmentService(
            AlefahDbContext alefahDb, 
            IDepartmentRepository Department
            )
        {
            this.alefahDb = alefahDb;
            this.Department = Department;
        }
        public async Task<GenericResult<Department>> Add(Department data)
        {
            GenericResult<Department> genericResults = new GenericResult<Department>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Department.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Department has been added successfully.";
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

        public async Task<GenericResult<Department>> Delete(int id)
        {
            GenericResult<Department> genericResults = new GenericResult<Department>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Department.GetById(id);
                    if (data != null)
                    {
                        var results = this.Department.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Department has been deleted successfully.";
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

        public async Task<GenericResult<Department>> Get(int id)
        {
            GenericResult<Department> genericResults = new GenericResult<Department>();
            try
            {
                var results = await this.Department.GetById(id);
                genericResults.status = true;
                genericResults.message = "Department's record has been found successfully.";
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

        public IQueryable<Department> GetAll(Expression<Func<Department, bool>>? filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>>? orderBy = null)
        {          
            try
            {
               return this.Department.GetAll(filter, orderBy);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<Department>> Update(Department data)
        {
            GenericResult<Department> genericResults = new GenericResult<Department>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Department.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Department has been updated successfully.";
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
