using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AlefahDbContext db;
        

        public CustomersRepository(AlefahDbContext db)
        {
            this.db = db;


        }

        public Customers Add(Customers entity)
        {
            try
            {
                this.db.Customers.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Customers Delete(Customers entity)
        {
            try
            {
                this.db.Customers.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<string> FileNumber()
        {

            ICollection<string> fileNumbers = new List<string>();
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "_FileNumber";
                command.CommandType = CommandType.StoredProcedure;

                db.Database.OpenConnection();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fileNumbers.Add(reader.GetFieldValue<string>(0));
                    }
                }
            }

            return fileNumbers.FirstOrDefault();

        }

        public async Task<Customers> GetById(int id)
        {
            return await this.db.Customers.FindAsync(id);
        }

        public IQueryable<Customers> GetAll(Expression<Func<Customers, bool>>? filter = null, Func<IQueryable<Customers>, IOrderedQueryable<Customers>>? orderBy = null)
        {
            try
            {

                IQueryable<Customers> query = this.db.Customers;
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

        public IQueryable<viewCustomers> GetAllCustomers(Expression<Func<viewCustomers, bool>>? filter = null, Func<IQueryable<viewCustomers>, IOrderedQueryable<viewCustomers>>? orderBy = null)
        {
            try
            {

                IQueryable<viewCustomers> query = this.db.viewCustomers;
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

        public Customers Update(Customers entity)
        {
            try
            {
                this.db.Customers.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
