using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class BranchSchedulesRepository : IBranchSchedulesRepository
    {
        private readonly AlefahDbContext db;
        public BranchSchedulesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public BranchSchedules Add(BranchSchedules entity)
        {
            try
            {
                this.db.BranchSchedules.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public BranchSchedules Delete(BranchSchedules entity)
        {
            try
            {


                if (entity != null)
                    this.db.BranchSchedules.Remove(entity);


                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<BranchSchedules> GetById(int id)
        {
            return await this.db.BranchSchedules.FindAsync(id);
        }

        public IQueryable<BranchSchedules> GetAll(Expression<Func<BranchSchedules, bool>>? filter = null, Func<IQueryable<BranchSchedules>, IOrderedQueryable<BranchSchedules>>? orderBy = null)
        {
            try
            {

                IQueryable<BranchSchedules> query = this.db.BranchSchedules;
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


        public BranchSchedules Update(BranchSchedules entity)
        {
            try
            {
                this.db.BranchSchedules.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
