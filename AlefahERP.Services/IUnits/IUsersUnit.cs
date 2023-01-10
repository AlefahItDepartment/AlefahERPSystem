using AlefahERP.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.IUnits
{
    public interface IUsersUnit
    {
        IUserRoleService UserRole { get; }
        IUsersService Users { get; }
    }
}
