using AlefahERP.Common;
using AlefahERP.DTO;
using AlefahERP.Repository;
using AlefahERP.Repository.Interfaces;
using AlefahERP.Services.Interfaces;
using AlefahERP.Common.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AlefahERP.Services.Implements
{
    internal class Employees1Service : IEmployees1Service
    {
        private readonly AlefahDbContext db;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployees1Repository employees1Repository;
        private readonly IEmployeesPicturesRepository employeesPicturesRepository;
        private readonly IEmployeesAddressRepository employeesAddressRepository;
        private readonly IEmployeesEmploymentsRepository employeesEmploymentsRepository;
        private readonly IEmployeesHealthInsuranceDetailsRepository employeesHealthInsuranceDetailsRepository;
        private readonly IEmployeesAttachmentsRepository employeesAttachmentsRepository;

        public Employees1Service(
            AlefahDbContext db,
            IUsersRepository usersRepository,
            IEmployees1Repository employees1Repository,
            IEmployeesPicturesRepository employeesPicturesRepository,
            IEmployeesAddressRepository employeesAddressRepository,
            IEmployeesEmploymentsRepository employeesEmploymentsRepository,
            IEmployeesHealthInsuranceDetailsRepository employeesHealthInsuranceDetailsRepository,
            IEmployeesAttachmentsRepository employeesAttachmentsRepository

            )
        {
            this.db = db;
            this.usersRepository = usersRepository;
            this.employees1Repository = employees1Repository;
            this.employeesPicturesRepository = employeesPicturesRepository;
            this.employeesAddressRepository = employeesAddressRepository;
            this.employeesEmploymentsRepository = employeesEmploymentsRepository;
            this.employeesHealthInsuranceDetailsRepository = employeesHealthInsuranceDetailsRepository;
            this.employeesAttachmentsRepository = employeesAttachmentsRepository;

        }
        public async Task<GenericResult<Employees1>> Add(Employee1RequestModel data)
        {
            GenericResult<Employees1> result = new GenericResult<Employees1>();


            try
            {
                using (var dbTrans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    Users userResult = null;
                    Employees1 employeeResult = null;
                    EmployeesPictures employeesPictures = null;
                    EmployeesEmployments employeesEmployments = null;

                    if (data.EmployeesEmployments != null)
                    {
                        userResult = this.usersRepository.Add(new Users
                        {

                            FullName = data.Employees1.DisplayName,
                            UserName = data.Employees1.Mobile,
                            Mobile = data.Employees1.Mobile,
                            Email = data.Employees1.Email,
                            Password = "Alefah!5380",
                            UserRoleID = data.EmployeesEmployments.UserRoleID,
                            CreatedDate = DateTime.Now
                        });
                    }

                    if (userResult != null)
                    {
                        data.Employees1.UserID = userResult.UserID;
                        data.Employees1.CreatedDateTime = DateTime.Now;
                        employeeResult = this.employees1Repository.Add(data.Employees1);

                        if (employeeResult != null)
                        {

                            if (!string.IsNullOrEmpty(data.UploadEmployeePicture))
                            {
                                data.EmployeesPictures = new EmployeesPictures();
                                data.EmployeesPictures.EmployeePictureData = System.Convert.FromBase64String(data.UploadEmployeePicture);
                                data.EmployeesPictures.EmployeeID = employeeResult.EmployeeID;
                                employeesPictures = this.employeesPicturesRepository.Add(data.EmployeesPictures);
                            }

                            if (data.EmployeesAddress != null)
                            {
                                data.EmployeesAddress.EmployeeID = employeeResult.EmployeeID;
                                this.employeesAddressRepository.Add(data.EmployeesAddress);
                            }

                            if (data.EmployeesEmployments != null)
                            {
                                data.EmployeesEmployments.EmployeeID = employeeResult.EmployeeID;
                                this.employeesEmploymentsRepository.Add(data.EmployeesEmployments);
                            }

                            if (data.EmployeesHealthInsuranceDetails != null)
                            {
                                data.EmployeesHealthInsuranceDetails.EmployeeID = employeeResult.EmployeeID;
                                this.employeesHealthInsuranceDetailsRepository.Add(data.EmployeesHealthInsuranceDetails);
                            }


                            if (data.EmployeesAttachments != null && data.EmployeesAttachments.Count > 0)
                            {
                                foreach (var attachment in data.EmployeesAttachments)
                                {
                                    attachment.EmployeeID = employeeResult.EmployeeID;
                                    this.employeesAttachmentsRepository.Add(attachment);
                                }
                            }

                            if (await db.SaveChangesAsync() > 0)
                            {
                                dbTrans.Complete();
                            }

                            result.status = true;
                            result.message = "Employee has been added successfuly.";
                            return result;

                        }
                        else
                        {
                            result.status = false;
                            result.message = "An error occured.";
                            return result;
                        }
                    }
                    else
                    {
                        result.status = false;
                        result.message = "An error occured.";
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.status = false;
                result.message = ex.Message;
                throw ex;
            }

        }

        public async Task<GenericResult<Employees1>> Delete(int id)
        {

            GenericResult<Employees1> result = new GenericResult<Employees1>();

            try
            {



                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<GenericResult<Employees1>> Get(int id)
        {
            try
            {

                return null;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Employees1> GetAll(Expression<Func<Employees1, bool>>? filter = null, Func<IQueryable<Employees1>, IOrderedQueryable<Employees1>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResult<Employees1>> Update(Employee1RequestModel data)
        {
            throw new NotImplementedException();
        }
    }
}
