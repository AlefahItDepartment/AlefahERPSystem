using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class AddressLineTypeRepository : IAddressLineTypeRepository
    {
        private readonly AlefahDbContext db;
        public AddressLineTypeRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public AddressLineType Add(AddressLineType entity)
        {
            try
            {

                this.db.AddressLineType.Add(entity);


                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AddressLineType Delete(AddressLineType entity)
        {           
            try
            {
                if (entity != null)
                {
                    this.db.AddressLineType.Remove(entity);
                }

                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AddressLineType> GetById(int id)
        {
            return await this.db.AddressLineType.FindAsync(id);
        }

        public IQueryable<AddressLineType> GetAll(Expression<Func<AddressLineType, bool>>? filter = null, Func<IQueryable<AddressLineType>, IOrderedQueryable<AddressLineType>>? orderBy = null)
        {
            try
            {

                IQueryable<AddressLineType> query = this.db.AddressLineType;
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


        public AddressLineType Update(AddressLineType entity)
        {
            try
            {

                this.db.AddressLineType.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
