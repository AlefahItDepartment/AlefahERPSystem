using AlefahERP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.IUnits
{
    public interface ISetupUnit
    {
        ICountryService Country { get; }
        IRegionService Region { get; }
        ICityService City { get; }
        IBranchesUnit Branches { get; }
        IDepartmentService Department { get; }
        IDesignationService Designation { get; }
        ICultureCodesService CultureCodes { get; }
        IAddressLineTypeService AddressLineType { get; }
        IBookingStatusService BookingStatus { get; }
        IMembershipCategoryService MembershipCategory { get; }
    }
}
