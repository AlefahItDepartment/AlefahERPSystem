using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetSpeciesRepository : IPetSpeciesRepository
    {
        private readonly AlefahDbContext db;
        public PetSpeciesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetSpecies Add(PetSpecies entity)
        {
            try
            {
                this.db.PetSpecies.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetSpecies Delete(PetSpecies entity)
        {
            try
            {

                this.db.PetSpecies.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetSpecies> GetById(int id)
        {
            return await this.db.PetSpecies.FindAsync(id);
        }

        public IQueryable<PetSpecies> GetAll(Expression<Func<PetSpecies, bool>>? filter = null, Func<IQueryable<PetSpecies>, IOrderedQueryable<PetSpecies>>? orderBy = null)
        {
            try
            {

                IQueryable<PetSpecies> query = this.db.PetSpecies;
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


        public PetSpecies Update(PetSpecies entity)
        {
            try
            {
                this.db.PetSpecies.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
