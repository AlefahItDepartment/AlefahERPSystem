using AlefahERP.Repository.Implements;
using AlefahERP.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Repository
{
    public static class ScopedServiceRepository
    {
        public static void AddScopedServiceRepository(this IServiceCollection services)
        {
            services.AddScoped<AlefahDbContext>();
            services.AddScoped<IAddressLineTypeRepository, AddressLineTypeRepository>();
            services.AddScoped<IBookingDetailsRepository, BookingDetailsRepository>();
            services.AddScoped<IBookingHeadRepository, BookingHeadRepository>();
            services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchSchedulesRepository, BranchSchedulesRepository>();
            services.AddScoped<ICultureCodesRepository, CultureCodesRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICustomersAddressLinesRepository, CustomersAddressLinesRepository>();
            services.AddScoped<ICustomersPETRepository, CustomersPETRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IMembershipCategoryRepository, MembershipCategoryRepository>();
            //services.AddScoped<IPetBloodChemistryDetailsRepository, PetBloodChemistryDetailsRepository>();
            //services.AddScoped<IPetBloodChemistryTypesRepository, PetBloodChemistryTypesRepository>();
            //services.AddScoped<IPetBloodScreenDetailsRepository, PetBloodScreenDetailsRepository>();
            //services.AddScoped<IPetBloodScreenTypesRepository, PetBloodScreenTypesRepository>();
            services.AddScoped<IPetBreedsRepository, PetBreedsRepository>();
            services.AddScoped<IPetColorsRepository, PetColorsRepository>();
            //services.AddScoped<IPetExamineDetailsRepository, PetExamineDetailsRepository>();
            //services.AddScoped<IPetExamineTypesRepository, PetExamineTypesRepository>();
            //services.AddScoped<IPetOriginsRepository, PetOriginsRepository>();
            services.AddScoped<IPetSizesRepository, PetSizesRepository>();
            services.AddScoped<IPetSpeciesRepository, PetSpeciesRepository>();
            //services.AddScoped<IPetSpeciesRepository, PetSpeciesRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IServiceDetailsRepository, ServiceDetailsRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IEmployees1Repository, Employees1Repository>();
            services.AddScoped<IEmployeesPicturesRepository, EmployeesPicturesRepository>();
            services.AddScoped<IEmployeesAddressRepository, EmployeesAddressRepository>();
            services.AddScoped<IEmployeesEmploymentsRepository, EmployeesEmploymentsRepository>();
            services.AddScoped<IEmployeesHealthInsuranceDetailsRepository, EmployeesHealthInsuranceDetailsRepository>();
            services.AddScoped<IEmployeesAttachmentsRepository, EmployeesAttachmentsRepository>();
        }
    }
}
