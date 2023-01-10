using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly AlefahDbContext _dbContext;
        public CountryRepository(AlefahDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Country Add(Country entity)
        {
            try
            {
                this._dbContext.Country.Add(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Country Delete(Country entity)
        {
            try
            {
                this._dbContext.Country.Remove(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Country> GetAll(Expression<Func<Country, bool>>? filter = null, Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null)
        {
            IQueryable<Country> query = this._dbContext.Country;
            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public async Task<Country> GetById(int id)
        {
            try
            {

                return await this._dbContext.Country.FindAsync(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country Update(Country entity)
        {
            try
            {

                this._dbContext.Country.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
