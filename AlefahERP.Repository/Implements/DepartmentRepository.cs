using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AlefahDbContext db;
        public DepartmentRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Department Add(Department entity)
        {
            try
            {

                this.db.Department.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Department Delete(Department entity)
        {
            try
            {
                this.db.Department.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Department> GetById(int id)
        {
            return await this.db.Department.FindAsync(id);
        }

        public IQueryable<Department> GetAll(Expression<Func<Department, bool>>? filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>>? orderBy = null)
        {
            try
            {

                IQueryable<Department> query = this.db.Department;
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


        public Department Update(Department entity)
        {
            try
            {

                this.db.Department.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
