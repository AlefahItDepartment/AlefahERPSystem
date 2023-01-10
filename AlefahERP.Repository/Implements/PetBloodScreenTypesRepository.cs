using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetBloodScreenTypesRepository : IPetBloodScreenTypesRepository
    {
        private readonly AlefahDbContext db;
        public PetBloodScreenTypesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetBloodScreenTypes Add(PetBloodScreenTypes entity)
        {
            try
            {

                this.db.PetBloodScreenTypes.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetBloodScreenTypes Delete(PetBloodScreenTypes entity)
        {
            try
            {


                this.db.PetBloodScreenTypes.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetBloodScreenTypes> GetById(int id)
        {
            return await this.db.PetBloodScreenTypes.FindAsync(id);
        }

        public IQueryable<PetBloodScreenTypes> GetAll(Expression<Func<PetBloodScreenTypes, bool>>? filter = null, Func<IQueryable<PetBloodScreenTypes>, IOrderedQueryable<PetBloodScreenTypes>>? orderBy = null)
        {
            try
            {

                IQueryable<PetBloodScreenTypes> query = this.db.PetBloodScreenTypes;
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


        public PetBloodScreenTypes Update(PetBloodScreenTypes entity)
        {
            try
            {

                this.db.PetBloodScreenTypes.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
