using AlefahERP.Services.IUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services
{
    public interface IUnitOfWork
    {
        ISetupUnit Setup { get; }
        ISettingUnit Setting { get; }
        IBranchesUnit Branches { get; }
        IEmployeesUnit Employees { get; }
        ICustomersUnit Customers { get; }
        IBookingUnit Booking { get; }
        IUsersUnit Users { get; }
        IPetCareUnit PetCare { get; }
        IItemsUnit Items { get; }

    }
}
