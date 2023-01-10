using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly AlefahDbContext db;
        public DesignationRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Designation Add(Designation entity)
        {
            try
            {

                this.db.Designation.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Designation Delete(Designation entity)
        {
            try
            {


                this.db.Designation.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Designation> GetById(int id)
        {
            return await this.db.Designation.FindAsync(id);
        }

        public IQueryable<Designation> GetAll(Expression<Func<Designation, bool>>? filter = null, Func<IQueryable<Designation>, IOrderedQueryable<Designation>>? orderBy = null)
        {
            try
            {
                IQueryable<Designation> query = this.db.Designation;
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


        public Designation Update(Designation entity)
        {
            try
            {
                this.db.Designation.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
