using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AlefahDbContext db;
        public BranchRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Branch Add(Branch entity)
        {
            try
            {

                this.db.Branch.Add(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Branch Delete(Branch entity)
        {
            try
            {

                if (entity != null)
                    this.db.Branch.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Branch> GetById(int id)
        {
            return await this.db.Branch.FindAsync(id);
        }

        public IQueryable<Branch> GetAll(Expression<Func<Branch, bool>>? filter = null, Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy = null)
        {
            try
            {

                IQueryable<Branch> query = this.db.Branch;
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

        public IQueryable<viewBranch> GetAllBranchs(Expression<Func<viewBranch, bool>>? filter = null, Func<IQueryable<viewBranch>, IOrderedQueryable<viewBranch>>? orderBy = null)
        {
            try
            {

                IQueryable<viewBranch> query = this.db.viewBranch;
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

        public Branch Update(Branch entity)
        {
            try
            {
                this.db.Branch.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
