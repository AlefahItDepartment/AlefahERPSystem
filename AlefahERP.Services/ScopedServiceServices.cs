using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlefahERP.Repository;
using AlefahERP.Services.IUnits;
using AlefahERP.Services.Units;
using AlefahERP.Services.Interfaces;
using AlefahERP.Bookings.Interfaces;
using AlefahERP.Services.Implements;

namespace AlefahERP.Services
{
    public static class ScopedServiceServices
    {
        public static void AddScopedServiceServices(this IServiceCollection services)
        {
            services.AddScopedServiceRepository();

            services.AddScoped<IAddressLineTypeService, AddressLineTypeService>();
            services.AddScoped<IBookingDetailsService, BookingDetailsService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingStatusService, BookingStatusService>();
            services.AddScoped<IBranchSchedulesService, BranchSchedulesService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICultureCodesService, CultureCodesService>();
            services.AddScoped<ICustomersAddressLinesService, CustomersAddressLinesService>();
            services.AddScoped<ICustomersPETService, CustomersPETService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDesignationService, DesignationService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IMembershipCategoryService, MembershipCategoryService>();
            //services.AddScoped<IPetBloodChemistryDetailsService, PetBloodChemistryDetailsService>();
            //services.AddScoped<IPetBloodChemistryTypesService, PetBloodChemistryTypesService>();
            //services.AddScoped<IPetBloodScreenDetailsService, PetBloodScreenDetailsService>();
            //services.AddScoped<IPetBloodScreenTypesService, PetBloodScreenTypesService>();
            services.AddScoped<IPetBreedsService, PetBreedsService>();
            services.AddScoped<IPetColorsService, PetColorsService>();
            //services.AddScoped<IPetExamineDetailsService, PetExamineDetailsService>();
            //services.AddScoped<IPetExamineTypesService, PetExamineTypesService>();
            //services.AddScoped<IPetOriginsService, PetOriginsService>();
            services.AddScoped<IPetSizesService, PetSizesService>();
            services.AddScoped<IPetSpeciesService, PetSpeciesService>();
            //services.AddScoped<IPetSpeciesService, PetSpeciesService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IServiceDetailsService, ServiceDetailsService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ISetupUnit, SetupUnit>();
            services.AddScoped<ISettingUnit, SettingUnit>();
            services.AddScoped<IBranchesUnit, BranchesUnit>();
            services.AddScoped<IEmployeesUnit, EmployeesUnit>();
            services.AddScoped<ICustomersUnit, CustomersUnit>();
            services.AddScoped<IBookingUnit, BookingUnit>();
            services.AddScoped<IUsersUnit, UsersUnit>();
            services.AddScoped<IPetCareUnit, PetCareUnit>();
            services.AddScoped<IItemsUnit, ItemsUnit>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
