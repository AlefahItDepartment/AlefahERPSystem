using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class ServiceDetailsRepository : IServiceDetailsRepository
    {
        private readonly AlefahDbContext db;
        public ServiceDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public ServiceDetails Add(ServiceDetails entity)
        {
            try
            {
                this.db.ServiceDetails.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ServiceDetails Delete(ServiceDetails entity)
        {

            try
            {
                this.db.ServiceDetails.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ServiceDetails> GetById(int id)
        {
            return await this.db.ServiceDetails.FindAsync(id);
        }

        public IQueryable<ServiceDetails> GetAll(Expression<Func<ServiceDetails, bool>>? filter = null, Func<IQueryable<ServiceDetails>, IOrderedQueryable<ServiceDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<ServiceDetails> query = this.db.ServiceDetails;
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

        public IQueryable<viewServiceDetails> GetViewServiceDetails(Expression<Func<viewServiceDetails, bool>>? filter = null, Func<IQueryable<viewServiceDetails>, IOrderedQueryable<viewServiceDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<viewServiceDetails> query = this.db.viewServiceDetails;
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

        public ServiceDetails Update(ServiceDetails entity)
        {
            try
            {
                this.db.ServiceDetails.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
