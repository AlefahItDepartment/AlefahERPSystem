using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class MembershipCategoryRepository : IMembershipCategoryRepository
    {
        private readonly AlefahDbContext db;
        public MembershipCategoryRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public MembershipCategory Add(MembershipCategory entity)
        {
            try
            {

                this.db.MembershipCategory.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MembershipCategory Delete(MembershipCategory entity)
        {
            try
            {

                this.db.MembershipCategory.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<MembershipCategory> GetById(int id)
        {
            return await this.db.MembershipCategory.FindAsync(id);
        }

        public IQueryable<MembershipCategory> GetAll(Expression<Func<MembershipCategory, bool>>? filter = null, Func<IQueryable<MembershipCategory>, IOrderedQueryable<MembershipCategory>>? orderBy = null)
        {
            try
            {

                IQueryable<MembershipCategory> query = this.db.MembershipCategory;
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


        public MembershipCategory Update(MembershipCategory entity)
        {
            try
            {

                this.db.MembershipCategory.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
