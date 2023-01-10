using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AlefahDbContext db;
        public RegionRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Region Add(Region entity)
        {
            try
            {
                this.db.Region.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Region Delete(Region entity)
        {
            try
            {
                this.db.Region.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Region> GetById(int id)
        {
            return await this.db.Region.FindAsync(id);
        }

        public IQueryable<Region> GetAll(Expression<Func<Region, bool>>? filter = null, Func<IQueryable<Region>, IOrderedQueryable<Region>>? orderBy = null)
        {
            try
            {

                IQueryable<Region> query = this.db.Region;
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


        public Region Update(Region entity)
        {
            try
            {
                this.db.Region.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
