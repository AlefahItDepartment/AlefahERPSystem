using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetSizesRepository : IPetSizesRepository
    {
        private readonly AlefahDbContext db;
        public PetSizesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetSizes Add(PetSizes entity)
        {
            try
            {
                this.db.PetSizes.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetSizes Delete(PetSizes entity)
        {
            try
            {

                this.db.PetSizes.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetSizes> GetById(int id)
        {
            return await this.db.PetSizes.FindAsync(id);
        }

        public IQueryable<PetSizes> GetAll(Expression<Func<PetSizes, bool>>? filter = null, Func<IQueryable<PetSizes>, IOrderedQueryable<PetSizes>>? orderBy = null)
        {
            try
            {

                IQueryable<PetSizes> query = this.db.PetSizes;
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


        public PetSizes Update(PetSizes entity)
        {
            try
            {
                this.db.PetSizes.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
