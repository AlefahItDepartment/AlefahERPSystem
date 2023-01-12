using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesEmploymentsRepository : IEmployeesEmploymentsRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesEmploymentsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public EmployeesEmployments Add(EmployeesEmployments entity)
        {
            try
            {

                this.db.EmployeesEmployments.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeesEmployments Delete(EmployeesEmployments entity)
        {

            try
            {
                this.db.EmployeesEmployments.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeesEmployments> GetById(int id)
        {
            return await this.db.EmployeesEmployments.FindAsync(id);
        }

        public IQueryable<EmployeesEmployments> GetAll(Expression<Func<EmployeesEmployments, bool>>? filter = null, Func<IQueryable<EmployeesEmployments>, IOrderedQueryable<EmployeesEmployments>>? orderBy = null)
        {
            try
            {

                IQueryable<EmployeesEmployments> query = this.db.EmployeesEmployments;
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

        public EmployeesEmployments Update(EmployeesEmployments entity)
        {
            try
            {
                this.db.EmployeesEmployments.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
