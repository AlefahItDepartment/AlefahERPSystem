using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetBreedsRepository : IPetBreedsRepository
    {
        private readonly AlefahDbContext db;
        public PetBreedsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetBreeds Add(PetBreeds entity)
        {
            try
            {
                this.db.PetBreeds.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetBreeds Delete(PetBreeds entity)
        {
            try
            {
                this.db.PetBreeds.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetBreeds> GetById(int id)
        {
            return await this.db.PetBreeds.FindAsync(id);
        }

        public IQueryable<PetBreeds> GetAll(Expression<Func<PetBreeds, bool>>? filter = null, Func<IQueryable<PetBreeds>, IOrderedQueryable<PetBreeds>>? orderBy = null)
        {
            try
            {

                IQueryable<PetBreeds> query = this.db.PetBreeds;
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


        public PetBreeds Update(PetBreeds entity)
        {
            try
            {
                this.db.PetBreeds.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
