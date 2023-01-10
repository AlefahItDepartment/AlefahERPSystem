using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class PetBloodChemistryTypesRepository : IPetBloodChemistryTypesRepository
    {
        private readonly AlefahDbContext db;
        public PetBloodChemistryTypesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public PetBloodChemistryTypes Add(PetBloodChemistryTypes entity)
        {
            try
            {
                this.db.PetBloodChemistryTypes.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PetBloodChemistryTypes Delete(PetBloodChemistryTypes entity)
        {
            try
            {

                this.db.PetBloodChemistryTypes.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<PetBloodChemistryTypes> GetById(int id)
        {
            return await this.db.PetBloodChemistryTypes.FindAsync(id);
        }

        public IQueryable<PetBloodChemistryTypes> GetAll(Expression<Func<PetBloodChemistryTypes, bool>>? filter = null, Func<IQueryable<PetBloodChemistryTypes>, IOrderedQueryable<PetBloodChemistryTypes>>? orderBy = null)
        {
            try
            {

                IQueryable<PetBloodChemistryTypes> query = this.db.PetBloodChemistryTypes;
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


        public PetBloodChemistryTypes Update(PetBloodChemistryTypes entity)
        {
            try
            {
                this.db.PetBloodChemistryTypes.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
