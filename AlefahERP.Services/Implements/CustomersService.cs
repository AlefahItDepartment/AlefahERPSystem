using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using AlefahERP.Services.RequestModels;
using AlefahERP.Services.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Services.Implements
{
    public class CustomersService : ICustomersService
    {
        private readonly AlefahDbContext alefahDb;
        private readonly ICustomersRepository customers;
        private readonly ICustomersAddressLinesRepository customersAddressLines;
        private readonly IUsersRepository users;
        private readonly IUserRoleRepository userRole;
        private readonly IMembershipCategoryRepository membershipCategory; 
        public CustomersService(
            AlefahDbContext alefahDb,
            ICustomersRepository customers,
            ICustomersAddressLinesRepository customerAddressLines,
            IUsersRepository users,
            IUserRoleRepository userRole,
            IMembershipCategoryRepository membershipCategory
            )
        {
            this.alefahDb = alefahDb;
            this.customers = customers;
            this.users = users;
            this.userRole = userRole;
            this.customersAddressLines  = customerAddressLines;
            this.membershipCategory = membershipCategory;   
        }
        public async Task<GenericResult<CustomerResponseModel>> Add(CustomerRequestModel data)
        {
            GenericResult<CustomerResponseModel> genericResults = new GenericResult<CustomerResponseModel>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    UserRole _userRole = await this.userRole.GetAll(x => x.UserRoleCode.ToLower() == "doctor").FirstOrDefaultAsync();

                    Users? _user = null;
                    if (data.User != null)
                    {
                        if (_userRole != null)
                            data.User.UserRoleID = _userRole.UserRoleID;
                        data.User.CreatedDate = DateTime.Now;

                        _user = this.users.Add(data.User);
                    }

                    if (_user != null)
                        data.Customer.UserID = _user.UserID;

                    data.Customer.CreatedDate = DateTime.Now;


                    var results = this.customers.Add(data.Customer);

                    if (results != null)
                    {

                        if (data.MailingAddress != null)
                        {

                            data.MailingAddress.CustomerID = results.CustomerID;

                            this.customersAddressLines.Add(data.MailingAddress);
                        }

                        if (data.BillingAddress != null)
                        {
                            data.BillingAddress.CustomerID = results.CustomerID;

                            this.customersAddressLines.Add(data.BillingAddress);
                        }

                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer has been added successfully.";
                            genericResults.data = new CustomerResponseModel();
                            genericResults.data.Customer = new viewCustomers();
                            genericResults.data.Customer = await this.customers.GetAllCustomers(x => x.CustomerID == results.CustomerID).FirstOrDefaultAsync();
                            genericResults.data.MailingAddress = new viewCustomerAddressLines();
                            genericResults.data.MailingAddress = await this.customersAddressLines.GetAllCustomersAddressLines(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 1).FirstOrDefaultAsync();
                            genericResults.data.BillingAddress = new viewCustomerAddressLines();
                            genericResults.data.BillingAddress = await this.customersAddressLines.GetAllCustomersAddressLines(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 2).FirstOrDefaultAsync();
                            genericResults.data.User = new viewUsers();
                            genericResults.data.User = await this.users.GetAllUsers(x => x.UserID == results.UserID).FirstOrDefaultAsync();
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

        public async Task<GenericResult<Customers>> Delete(int id)
        {
            GenericResult<Customers> genericResults = new GenericResult<Customers>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var data = await this.customers.GetById(id);
                    if (data != null)
                    {



                        this.users.Delete(await this.users.GetById(data.UserID));

                        var mailingAddress = await this.customersAddressLines.GetAll(x => x.CustomerID == data.CustomerID && x.AddressLineTypeID == 1).FirstOrDefaultAsync();

                        if (mailingAddress != null)
                            this.customersAddressLines.Delete(mailingAddress);

                        var billingAddress = await this.customersAddressLines.GetAll(x => x.CustomerID == data.CustomerID && x.AddressLineTypeID == 2).FirstOrDefaultAsync();

                        if (billingAddress != null)
                            this.customersAddressLines.Delete(billingAddress);


                        var results = this.customers.Delete(data);

                        if (results != null)
                        {
                            if (await this.alefahDb.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();

                                genericResults.status = true;
                                genericResults.message = "Customer has been deleted successfully.";
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

        public async Task<GenericResult<Customers>> Get(int id)
        {
            GenericResult<Customers> genericResults = new GenericResult<Customers>();
            try
            {
                var results = await this.customers.GetById(id);
                genericResults.status = true;
                genericResults.message = "Customers's record has been found successfully.";
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

        public IQueryable<viewCustomers> GetAll(Expression<Func<viewCustomers, bool>>? filter = null, Func<IQueryable<viewCustomers>, IOrderedQueryable<viewCustomers>>? orderBy = null)
        {
            try
            {
              return  this.customers.GetAllCustomers(filter, orderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GenericResult<CustomerResponseModel>> Update(CustomerRequestModel data)
        {
            GenericResult<CustomerResponseModel> genericResults = new GenericResult<CustomerResponseModel>();
            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var results = this.customers.Update(data.Customer);

                    if (results != null)
                    {

                        if (data.MailingAddress != null)
                        {
                            var mailingAddress = await this.customersAddressLines.GetAll(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 1).FirstOrDefaultAsync();

                            if (mailingAddress != null)
                                this.customersAddressLines.Delete(mailingAddress);


                            data.MailingAddress.CustomerID = results.CustomerID;
                            this.customersAddressLines.Add(data.MailingAddress);
                        }

                        if (data.BillingAddress != null)
                        {
                            var billingAddress = await this.customersAddressLines.GetAll(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 2).FirstOrDefaultAsync();

                            if (billingAddress != null)
                                this.customersAddressLines.Delete(billingAddress);

                            data.BillingAddress.CustomerID = results.CustomerID;
                            this.customersAddressLines.Add(data.BillingAddress);
                        }


                        if (data.User != null)
                        {
                            data.User.UpdatedDate = DateTime.Now;
                            this.users.Update(data.User);
                        }


                        if (await this.alefahDb.SaveChangesAsync() > 0)
                        {
                            dbTrans.Complete();

                            genericResults.status = true;
                            genericResults.message = "Customer has been updated successfully.";
                            genericResults.data = new CustomerResponseModel();
                            genericResults.data.Customer = new viewCustomers();
                            genericResults.data.Customer = await this.customers.GetAllCustomers(x => x.CustomerID == results.CustomerID).FirstOrDefaultAsync();
                            genericResults.data.MailingAddress = new viewCustomerAddressLines();
                            genericResults.data.MailingAddress = await this.customersAddressLines.GetAllCustomersAddressLines(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 1).FirstOrDefaultAsync();
                            genericResults.data.BillingAddress = new viewCustomerAddressLines();
                            genericResults.data.BillingAddress = await this.customersAddressLines.GetAllCustomersAddressLines(x => x.CustomerID == results.CustomerID && x.AddressLineTypeID == 2).FirstOrDefaultAsync();
                            genericResults.data.User = new viewUsers();
                            genericResults.data.User = await this.users.GetAllUsers(x => x.UserID == results.UserID).FirstOrDefaultAsync();
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
