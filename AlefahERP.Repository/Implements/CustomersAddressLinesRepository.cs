using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class CustomersAddressLinesRepository : ICustomersAddressLinesRepository
    {
        private readonly AlefahDbContext db;
        public CustomersAddressLinesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public CustomersAddressLines Add(CustomersAddressLines entity)
        {
            try
            {
                this.db.CustomersAddressLines.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CustomersAddressLines Delete(CustomersAddressLines entity)
        {

            try
            {
                this.db.CustomersAddressLines.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CustomersAddressLines> GetById(int id)
        {
            return await this.db.CustomersAddressLines.FindAsync(id);
        }

        public IQueryable<CustomersAddressLines> GetAll(Expression<Func<CustomersAddressLines, bool>>? filter = null, Func<IQueryable<CustomersAddressLines>, IOrderedQueryable<CustomersAddressLines>>? orderBy = null)
        {
            try
            {

                IQueryable<CustomersAddressLines> query = this.db.CustomersAddressLines;
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

        public IQueryable<viewCustomerAddressLines> GetAllCustomersAddressLines(Expression<Func<viewCustomerAddressLines, bool>>? filter = null, Func<IQueryable<viewCustomerAddressLines>, IOrderedQueryable<viewCustomerAddressLines>>? orderBy = null)
        {
            try
            {

                IQueryable<viewCustomerAddressLines> query = this.db.viewCustomerAddressLines;
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

        public CustomersAddressLines Update(CustomersAddressLines entity)
        {
            try
            {
                this.db.CustomersAddressLines.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
