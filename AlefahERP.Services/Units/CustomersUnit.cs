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
    public class CustomersUnit : ICustomersUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public CustomersUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }

        public ICustomersService Customers => _serviceProvider.GetRequiredService<ICustomersService>();

        public ICustomersPETService CustomersPET => _serviceProvider.GetRequiredService<ICustomersPETService>();

        public ICustomersAddressLinesService CustomersAddressLines => _serviceProvider.GetRequiredService<ICustomersAddressLinesService>();
    }
}
