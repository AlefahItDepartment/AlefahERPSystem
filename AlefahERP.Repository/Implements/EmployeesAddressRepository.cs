using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesAddressRepository : IEmployeesAddressRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesAddressRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public EmployeesAddress Add(EmployeesAddress entity)
        {
            try
            {

                this.db.EmployeesAddress.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeesAddress Delete(EmployeesAddress entity)
        {

            try
            {
                this.db.EmployeesAddress.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeesAddress> GetById(int id)
        {
            return await this.db.EmployeesAddress.FindAsync(id);
        }

        public IQueryable<EmployeesAddress> GetAll(Expression<Func<EmployeesAddress, bool>>? filter = null, Func<IQueryable<EmployeesAddress>, IOrderedQueryable<EmployeesAddress>>? orderBy = null)
        {
            try
            {

                IQueryable<EmployeesAddress> query = this.db.EmployeesAddress;
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

        public EmployeesAddress Update(EmployeesAddress entity)
        {
            try
            {
                this.db.EmployeesAddress.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
