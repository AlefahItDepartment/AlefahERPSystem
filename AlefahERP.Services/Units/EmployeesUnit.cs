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
    public class EmployeesUnit : IEmployeesUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public EmployeesUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }

        public IEmployeesService Employees => _serviceProvider.GetRequiredService<IEmployeesService>();
    }
}
