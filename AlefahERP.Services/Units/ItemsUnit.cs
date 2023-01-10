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
    public class ItemsUnit : IItemsUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public ItemsUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }


        public IServiceTypeService ServiceType => _serviceProvider.GetRequiredService<IServiceTypeService>();

        public IServiceDetailsService ServiceDetails => _serviceProvider.GetRequiredService<IServiceDetailsService>();
    }
}
