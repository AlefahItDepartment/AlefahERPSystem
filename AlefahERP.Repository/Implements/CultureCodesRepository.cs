using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class CultureCodesRepository : ICultureCodesRepository
    {
        private readonly AlefahDbContext db;
        public CultureCodesRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public CultureCodes Add(CultureCodes entity)
        {
            try
            {

                this.db.CultureCodes.Add(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CultureCodes Delete(CultureCodes entity)
        {
            try
            {


                this.db.CultureCodes.Remove(entity);
                return entity;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CultureCodes> GetById(int id)
        {
            return await this.db.CultureCodes.FindAsync(id);
        }

        public IQueryable<CultureCodes> GetAll(Expression<Func<CultureCodes, bool>>? filter = null, Func<IQueryable<CultureCodes>, IOrderedQueryable<CultureCodes>>? orderBy = null)
        {
            try
            {

                IQueryable<CultureCodes> query = this.db.CultureCodes;
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


        public CultureCodes Update(CultureCodes entity)
        {
            try
            {
                this.db.CultureCodes.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
