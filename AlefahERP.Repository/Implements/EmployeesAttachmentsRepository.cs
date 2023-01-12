using AlefahERP.DTO;
using AlefahERP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace AlefahERP.Repository.Implements
{
    public class EmployeesAttachmentsRepository : IEmployeesAttachmentsRepository
    {
        private readonly AlefahDbContext db;
        public EmployeesAttachmentsRepository(AlefahDbContext db)
        {
            this.db = db;
        }

        public EmployeesAttachments Add(EmployeesAttachments entity)
        {
            try
            {

                this.db.EmployeesAttachments.Add(entity);

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeesAttachments Delete(EmployeesAttachments entity)
        {

            try
            {
                this.db.EmployeesAttachments.Remove(entity);
                return entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<EmployeesAttachments> GetById(int id)
        {
            return await this.db.EmployeesAttachments.FindAsync(id);
        }

        public IQueryable<EmployeesAttachments> GetAll(Expression<Func<EmployeesAttachments, bool>>? filter = null, Func<IQueryable<EmployeesAttachments>, IOrderedQueryable<EmployeesAttachments>>? orderBy = null)
        {
            try
            {

                IQueryable<EmployeesAttachments> query = this.db.EmployeesAttachments;
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

        public EmployeesAttachments Update(EmployeesAttachments entity)
        {
            try
            {
                this.db.EmployeesAttachments.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
