using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Services.Implements
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly IFeedbackRepository Feedback;
        public FeedbackService(
            AlefahDbContext alefahDb, 
            IFeedbackRepository Feedback
            )
        {
            this.alefahDb = alefahDb;
            this.Feedback = Feedback;
        }
        public async Task<GenericResult<Feedback>> Add(Feedback data)
        {
            GenericResult<Feedback> genericResults = new GenericResult<Feedback>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Feedback.Add(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Feedback has been added successfully.";
                            genericResults.data = results;
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {               
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public async Task<GenericResult<Feedback>> Delete(int id)
        {
            GenericResult<Feedback> genericResults = new GenericResult<Feedback>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.Feedback.GetById(id);
                    if (data != null)
                    {
                        var results = this.Feedback.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Feedback has been deleted successfully.";
                                genericResults.data = results;
                            }
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public async Task<GenericResult<Feedback>> Get(int id)
        {
            GenericResult<Feedback> genericResults = new GenericResult<Feedback>();
            try
            {
                var results = await this.Feedback.GetById(id);
                genericResults.status = true;
                genericResults.message = "Feedback's record has been found successfully.";
                genericResults.data = results;

                return genericResults;
            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }

        public IQueryable<Feedback> GetAll(Expression<Func<Feedback, bool>>? filter = null, Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>>? orderBy = null)
        {
            try
            {
               return this.Feedback.GetAll(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<Feedback>> Update(Feedback data)
        {
            GenericResult<Feedback> genericResults = new GenericResult<Feedback>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    var results = this.Feedback.Update(data);

                    if (results != null)
                    {
                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Feedback has been updated successfully.";
                            genericResults.data = results;
                        }
                    }
                }

                return genericResults;

            }
            catch (Exception ex)
            {
                genericResults.status = false;
                genericResults.message = ex.Message;
                return genericResults;
            }
        }
    }
}
