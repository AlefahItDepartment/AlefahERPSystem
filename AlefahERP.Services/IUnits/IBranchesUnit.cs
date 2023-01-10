using AlefahERP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.IUnits
{
    public interface IBranchesUnit
    {
        IBranchService Branch { get; }
        IBranchSchedulesService BranchSchedules { get; }
    }
}
