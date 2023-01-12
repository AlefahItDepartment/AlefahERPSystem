using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesHealthInsuranceDetailsRepository : IEmployeesHealthInsuranceDetailsRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesHealthInsuranceDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public EmployeesHealthInsuranceDetails Add(EmployeesHealthInsuranceDetails entity)
        {
            try
            {

                this.db.EmployeesHealthInsuranceDetails.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeesHealthInsuranceDetails Delete(EmployeesHealthInsuranceDetails entity)
        {

            try
            {
                this.db.EmployeesHealthInsuranceDetails.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeesHealthInsuranceDetails> GetById(int id)
        {
            return await this.db.EmployeesHealthInsuranceDetails.FindAsync(id);
        }

        public IQueryable<EmployeesHealthInsuranceDetails> GetAll(Expression<Func<EmployeesHealthInsuranceDetails, bool>>? filter = null, Func<IQueryable<EmployeesHealthInsuranceDetails>, IOrderedQueryable<EmployeesHealthInsuranceDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<EmployeesHealthInsuranceDetails> query = this.db.EmployeesHealthInsuranceDetails;
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

        public EmployeesHealthInsuranceDetails Update(EmployeesHealthInsuranceDetails entity)
        {
            try
            {
                this.db.EmployeesHealthInsuranceDetails.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
