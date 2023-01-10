using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AlefahDbContext db;
        public FeedbackRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public Feedback Add(Feedback entity)
        {
            try
            {
                this.db.Feedback.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Feedback Delete(Feedback entity)
        {
            try
            {


                this.db.Feedback.Remove(entity);

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Feedback> GetById(int id)
        {
            return await this.db.Feedback.FindAsync(id);
        }

        public IQueryable<Feedback> GetAll(Expression<Func<Feedback, bool>>? filter = null, Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>>? orderBy = null)
        {
            try
            {

                IQueryable<Feedback> query = this.db.Feedback;
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


        public Feedback Update(Feedback entity)
        {
            try
            {
                this.db.Feedback.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
