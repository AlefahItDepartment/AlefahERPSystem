using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetSubSpeciesRepository : IPetSubSpeciesRepository
    {
        private readonly AlefahDbContext db;
        public PetSubSpeciesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetSubSpecies Add(PetSubSpecies entity)
        {
            try
            {
                this.db.PetSubSpecies.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetSubSpecies Delete(PetSubSpecies entity)
        {
            try
            {
                this.db.PetSubSpecies.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetSubSpecies> GetById(int id)
        {
            return await this.db.PetSubSpecies.FindAsync(id);
        }

        public IQueryable<PetSubSpecies> GetAll(Expression<Func<PetSubSpecies, bool>>? filter = null, Func<IQueryable<PetSubSpecies>, IOrderedQueryable<PetSubSpecies>>? orderBy = null)
        {
            try
            {

                IQueryable<PetSubSpecies> query = this.db.PetSubSpecies;
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


        public PetSubSpecies Update(PetSubSpecies entity)
        {
            try
            {
                this.db.PetSubSpecies.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
