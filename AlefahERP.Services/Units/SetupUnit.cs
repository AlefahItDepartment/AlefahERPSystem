using AlefahERP.Services.Interfaces;
using AlefahERP.Services.IUnits;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.Units
{
    public class SetupUnit : ISetupUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public SetupUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }
        public ICountryService Country => _serviceProvider.GetRequiredService<ICountryService>();

        public IRegionService Region => _serviceProvider.GetRequiredService<IRegionService>();

        public ICityService City => _serviceProvider.GetRequiredService<ICityService>();

        public IBranchesUnit Branches => _serviceProvider.GetRequiredService<IBranchesUnit>();

        public IDepartmentService Department => _serviceProvider.GetRequiredService<IDepartmentService>();

        public IDesignationService Designation => _serviceProvider.GetRequiredService<IDesignationService>();

        public ICultureCodesService CultureCodes => _serviceProvider.GetRequiredService<ICultureCodesService>();

        public IAddressLineTypeService AddressLineType => _serviceProvider.GetRequiredService<IAddressLineTypeService>();

        public IBookingStatusService BookingStatus => _serviceProvider.GetRequiredService<IBookingStatusService>();

        public IMembershipCategoryService MembershipCategory => _serviceProvider.GetRequiredService<IMembershipCategoryService>();
    }
}
