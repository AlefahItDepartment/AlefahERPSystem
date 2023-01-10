using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AlefahDbContext db;
        public UserRoleRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public UserRole Add(UserRole entity)
        {
            try
            {
                this.db.UserRole.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public UserRole Delete(UserRole entity)
        {
            try
            {
                this.db.UserRole.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<UserRole> GetById(int id)
        {
            return await this.db.UserRole.FindAsync(id);
        }

        public IQueryable<UserRole> GetAll(Expression<Func<UserRole, bool>>? filter = null, Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy = null)
        {
            try
            {

                IQueryable<UserRole> query = this.db.UserRole;
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


        public UserRole Update(UserRole entity)
        {
            try
            {
                this.db.UserRole.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
