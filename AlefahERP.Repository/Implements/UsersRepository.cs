using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AlefahDbContext db;
        public UsersRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Users Add(Users entity)
        {
            try
            {
                this.db.Users.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Users Delete(Users entity)
        {
            try
            {

                this.db.Users.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Users> GetById(int id)
        {
            return await this.db.Users.FindAsync(id);
        }

        public IQueryable<Users> GetAll(Expression<Func<Users, bool>>? filter = null, Func<IQueryable<Users>, IOrderedQueryable<Users>>? orderBy = null)
        {
            try
            {

                IQueryable<Users> query = this.db.Users;
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

        public IQueryable<viewUsers> GetAllUsers(Expression<Func<viewUsers, bool>>? filter = null, Func<IQueryable<viewUsers>, IOrderedQueryable<viewUsers>>? orderBy = null)
        {
            try
            {

                IQueryable<viewUsers> query = this.db.viewUsers;
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

        public Users Update(Users entity)
        {
            try
            {
                this.db.Users.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
