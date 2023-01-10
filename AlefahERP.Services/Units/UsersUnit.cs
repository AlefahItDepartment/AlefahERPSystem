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
    public class UsersUnit : IUsersUnit
    {
        private readonly IServiceProvider _serviceProvider;
        public UsersUnit(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }
        public IUserRoleService UserRole => _serviceProvider.GetRequiredService<IUserRoleService>();
        public IUsersService Users => _serviceProvider.GetRequiredService<IUsersService>();
    }
}
