using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetExamineDetailsRepository : IPetExamineDetailsRepository
    {
        private readonly AlefahDbContext db;
        public PetExamineDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetExamineDetails Add(PetExamineDetails entity)
        {
            try
            {

                this.db.PetExamineDetails.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetExamineDetails Delete(PetExamineDetails entity)
        {
            try
            {


                this.db.PetExamineDetails.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetExamineDetails> GetById(int id)
        {
            return await this.db.PetExamineDetails.FindAsync(id);
        }

        public IQueryable<PetExamineDetails> GetAll(Expression<Func<PetExamineDetails, bool>>? filter = null, Func<IQueryable<PetExamineDetails>, IOrderedQueryable<PetExamineDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<PetExamineDetails> query = this.db.PetExamineDetails;
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


        public PetExamineDetails Update(PetExamineDetails entity)
        {
            try
            {
                this.db.PetExamineDetails.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
