using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly AlefahDbContext db;
        public ServiceTypeRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public ServiceType Add(ServiceType entity)
        {
            try
            {
                this.db.ServiceType.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ServiceType Delete(ServiceType entity)
        {
            try
            {
                this.db.ServiceType.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ServiceType> GetById(int id)
        {
            return await this.db.ServiceType.FindAsync(id);
        }

        public IQueryable<ServiceType> GetAll(Expression<Func<ServiceType, bool>>? filter = null, Func<IQueryable<ServiceType>, IOrderedQueryable<ServiceType>>? orderBy = null)
        {
            try
            {

                IQueryable<ServiceType> query = this.db.ServiceType;
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


        public ServiceType Update(ServiceType entity)
        {
            try
            {
                this.db.ServiceType.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
