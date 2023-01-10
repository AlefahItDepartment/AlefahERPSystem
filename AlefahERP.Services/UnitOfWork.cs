using AlefahERP.Services.IUnits;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWork(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
        }
        public ISetupUnit Setup => this._serviceProvider.GetRequiredService<ISetupUnit>();

        public ISettingUnit Setting => this._serviceProvider.GetRequiredService<ISettingUnit>();

        public IBranchesUnit Branches => this._serviceProvider.GetRequiredService<IBranchesUnit>();

        public IEmployeesUnit Employees => this._serviceProvider.GetRequiredService<IEmployeesUnit>();

        public ICustomersUnit Customers => this._serviceProvider.GetRequiredService<ICustomersUnit>();

        public IBookingUnit Booking => this._serviceProvider.GetRequiredService<IBookingUnit>();

        public IUsersUnit Users => this._serviceProvider.GetRequiredService<IUsersUnit>();

        public IPetCareUnit PetCare => this._serviceProvider.GetRequiredService<IPetCareUnit>();

        public IItemsUnit Items => this._serviceProvider.GetRequiredService<IItemsUnit>();
    }
}
