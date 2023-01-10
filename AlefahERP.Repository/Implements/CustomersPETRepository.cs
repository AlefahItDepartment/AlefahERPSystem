using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class CustomersPETRepository : ICustomersPETRepository
    {
        private readonly AlefahDbContext db;
        public CustomersPETRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public CustomersPET Add(CustomersPET entity)
        {
            try
            {

                this.db.CustomersPET.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CustomersPET Delete(CustomersPET entity)
        {
            try
            {

                this.db.CustomersPET.Remove(entity);

                return entity;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CustomersPET> GetById(int id)
        {
            return await this.db.CustomersPET.FindAsync(id);
        }

        public IQueryable<CustomersPET> GetAll(Expression<Func<CustomersPET, bool>>? filter = null, Func<IQueryable<CustomersPET>, IOrderedQueryable<CustomersPET>>? orderBy = null)
        {
            try
            {

                IQueryable<CustomersPET> query = this.db.CustomersPET;
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


        public CustomersPET Update(CustomersPET entity)
        {
            try
            {

                this.db.CustomersPET.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<viewCustomersPET> GetAllCustomersPET(Expression<Func<viewCustomersPET, bool>>? filter = null, Func<IQueryable<viewCustomersPET>, IOrderedQueryable<viewCustomersPET>>? orderBy = null)
        {
            try
            {

                IQueryable<viewCustomersPET> query = this.db.viewCustomersPET;
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
    }
}
