using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class Employees1Repository : IEmployees1Repository
    {
        private readonly AlefahDbContext db;
        public Employees1Repository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Employees1 Add(Employees1 entity)
        {
            try
            {

                this.db.Employees1.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Employees1 Delete(Employees1 entity)
        {

            try
            {
                this.db.Employees1.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Employees1> GetById(int id)
        {
            return await this.db.Employees1.FindAsync(id);
        }

        public IQueryable<Employees1> GetAll(Expression<Func<Employees1, bool>>? filter = null, Func<IQueryable<Employees1>, IOrderedQueryable<Employees1>>? orderBy = null)
        {
            try
            {

                IQueryable<Employees1> query = this.db.Employees1;
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

        public IQueryable<viewEmployees> GetAllEmployees(Expression<Func<viewEmployees, bool>>? filter = null, Func<IQueryable<viewEmployees>, IOrderedQueryable<viewEmployees>>? orderBy = null)
        {
            try
            {

                IQueryable<viewEmployees> query = this.db.viewEmployees;
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

        public Employees1 Update(Employees1 entity)
        {
            try
            {
                this.db.Employees1.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
