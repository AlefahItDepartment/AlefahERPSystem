using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetColorsRepository : IPetColorsRepository
    {
        private readonly AlefahDbContext db;
        public PetColorsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetColors Add(PetColors entity)
        {
            try
            {

                this.db.PetColors.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetColors Delete(PetColors entity)
        {
            try
            {
                this.db.PetColors.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetColors> GetById(int id)
        {
            return await this.db.PetColors.FindAsync(id);
        }

        public IQueryable<PetColors> GetAll(Expression<Func<PetColors, bool>>? filter = null, Func<IQueryable<PetColors>, IOrderedQueryable<PetColors>>? orderBy = null)
        {
            try
            {

                IQueryable<PetColors> query = this.db.PetColors;
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


        public PetColors Update(PetColors entity)
        {
            try
            {
                this.db.PetColors.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
