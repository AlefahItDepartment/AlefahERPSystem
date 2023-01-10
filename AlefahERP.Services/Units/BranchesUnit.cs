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
    public class BranchesUnit : IBranchesUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public BranchesUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }

        public IBranchService Branch => _serviceProvider.GetRequiredService<IBranchService>();

        public IBranchSchedulesService BranchSchedules => _serviceProvider.GetRequiredService<IBranchSchedulesService>();
    }
}
