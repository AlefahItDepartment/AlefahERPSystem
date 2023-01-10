using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetOriginsRepository : IPetOriginsRepository
    {
        private readonly AlefahDbContext db;
        public PetOriginsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetOrigins Add(PetOrigins entity)
        {
            try
            {

                this.db.PetOrigins.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetOrigins Delete(PetOrigins entity)
        {

            try
            {

                this.db.PetOrigins.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetOrigins> GetById(int id)
        {
            return await this.db.PetOrigins.FindAsync(id);
        }

        public IQueryable<PetOrigins> GetAll(Expression<Func<PetOrigins, bool>>? filter = null, Func<IQueryable<PetOrigins>, IOrderedQueryable<PetOrigins>>? orderBy = null)
        {
            try
            {

                IQueryable<PetOrigins> query = this.db.PetOrigins;
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


        public PetOrigins Update(PetOrigins entity)
        {
            try
            {
                this.db.PetOrigins.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
