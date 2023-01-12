using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesPicturesRepository : IEmployeesPicturesRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesPicturesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public EmployeesPictures Add(EmployeesPictures entity)
        {
            try
            {

                this.db.EmployeesPictures.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeesPictures Delete(EmployeesPictures entity)
        {

            try
            {
                this.db.EmployeesPictures.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeesPictures> GetById(int id)
        {
            return await this.db.EmployeesPictures.FindAsync(id);
        }

        public IQueryable<EmployeesPictures> GetAll(Expression<Func<EmployeesPictures, bool>>? filter = null, Func<IQueryable<EmployeesPictures>, IOrderedQueryable<EmployeesPictures>>? orderBy = null)
        {
            try
            {

                IQueryable<EmployeesPictures> query = this.db.EmployeesPictures;
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

        public EmployeesPictures Update(EmployeesPictures entity)
        {
            try
            {
                this.db.EmployeesPictures.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
