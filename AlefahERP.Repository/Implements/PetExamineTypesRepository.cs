using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetExamineTypesRepository : IPetExamineTypesRepository
    {
        private readonly AlefahDbContext db;
        public PetExamineTypesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetExamineTypes Add(PetExamineTypes entity)
        {
            try
            {
                this.db.PetExamineTypes.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetExamineTypes Delete(PetExamineTypes entity)
        {
            try
            {
                this.db.PetExamineTypes.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetExamineTypes> GetById(int id)
        {
            return await this.db.PetExamineTypes.FindAsync(id);
        }

        public IQueryable<PetExamineTypes> GetAll(Expression<Func<PetExamineTypes, bool>>? filter = null, Func<IQueryable<PetExamineTypes>, IOrderedQueryable<PetExamineTypes>>? orderBy = null)
        {
            try
            {

                IQueryable<PetExamineTypes> query = this.db.PetExamineTypes;
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


        public PetExamineTypes Update(PetExamineTypes entity)
        {
            try
            {
                this.db.PetExamineTypes.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
