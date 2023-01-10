using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class CityRepository : ICityRepository
    {
        private readonly AlefahDbContext db;
        public CityRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public City Add(City entity)
        {
            try
            {

                this.db.City.Add(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public City Delete(City entity)
        {
            try
            {

                if (entity != null)
                    this.db.City.Remove(entity);


                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<City> GetById(int id)
        {
            return await this.db.City.FindAsync(id);
        }

        public IQueryable<City> GetAll(Expression<Func<City, bool>>? filter = null, Func<IQueryable<City>, IOrderedQueryable<City>>? orderBy = null)
        {
            try
            {

                IQueryable<City> query = this.db.City;
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


        public City Update(City entity)
        {
            try
            {

                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    this.db.City.Update(entity);

                }

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
