using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Employees Add(Employees entity)
        {
            try
            {

                this.db.Employees.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employees Delete(Employees entity)
        {

            try
            {
                this.db.Employees.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employees> GetById(int id)
        {
            return await this.db.Employees.FindAsync(id);
        }

        public IQueryable<Employees> GetAll(Expression<Func<Employees, bool>>? filter = null, Func<IQueryable<Employees>, IOrderedQueryable<Employees>>? orderBy = null)
        {
            try
            {

                IQueryable<Employees> query = this.db.Employees;
                if (filter != null)
                    query = query.Where(filter);
                if (orderBy != null)
                    query = orderBy(query);


                return query;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<viewEmployees> GetAllEmployees(Expression<Func<viewEmployees, bool>>? filter = null, Func<IQueryable<viewEmployees>, IOrderedQueryable<viewEmployees>>? orderBy = null)
        {
            try
            {

                IQueryable<viewEmployees> query = this.db.viewEmployees;
                if (filter != null)
                    query = query.Where(filter);
                if (orderBy != null)
                    query = orderBy(query);


                return query;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employees Update(Employees entity)
        {
            try
            {
                this.db.Employees.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
