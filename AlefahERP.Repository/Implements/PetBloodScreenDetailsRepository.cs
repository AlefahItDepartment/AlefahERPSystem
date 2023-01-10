using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetBloodScreenDetailsRepository : IPetBloodScreenDetailsRepository
    {
        private readonly AlefahDbContext db;
        public PetBloodScreenDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetBloodScreenDetails Add(PetBloodScreenDetails entity)
        {
            try
            {
                this.db.PetBloodScreenDetails.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetBloodScreenDetails Delete(PetBloodScreenDetails entity)
        {

            try
            {

                this.db.PetBloodScreenDetails.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetBloodScreenDetails> GetById(int id)
        {
            return await this.db.PetBloodScreenDetails.FindAsync(id);
        }

        public IQueryable<PetBloodScreenDetails> GetAll(Expression<Func<PetBloodScreenDetails, bool>>? filter = null, Func<IQueryable<PetBloodScreenDetails>, IOrderedQueryable<PetBloodScreenDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<PetBloodScreenDetails> query = this.db.PetBloodScreenDetails;
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


        public PetBloodScreenDetails Update(PetBloodScreenDetails entity)
        {
            try
            {
                this.db.PetBloodScreenDetails.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
