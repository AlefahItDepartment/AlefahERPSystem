using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetBloodChemistryDetailsRepository : IPetBloodChemistryDetailsRepository
    {
        private readonly AlefahDbContext db;
        public PetBloodChemistryDetailsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetBloodChemistryDetails Add(PetBloodChemistryDetails entity)
        {
            try
            {
                this.db.PetBloodChemistryDetails.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetBloodChemistryDetails Delete(PetBloodChemistryDetails entity)
        {
            try
            {


                this.db.PetBloodChemistryDetails.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetBloodChemistryDetails> GetById(int id)
        {
            return await this.db.PetBloodChemistryDetails.FindAsync(id);
        }

        public IQueryable<PetBloodChemistryDetails> GetAll(Expression<Func<PetBloodChemistryDetails, bool>>? filter = null, Func<IQueryable<PetBloodChemistryDetails>, IOrderedQueryable<PetBloodChemistryDetails>>? orderBy = null)
        {
            try
            {

                IQueryable<PetBloodChemistryDetails> query = this.db.PetBloodChemistryDetails;
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

        public PetBloodChemistryDetails Update(PetBloodChemistryDetails entity)
        {
            try
            {
                this.db.PetBloodChemistryDetails.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
