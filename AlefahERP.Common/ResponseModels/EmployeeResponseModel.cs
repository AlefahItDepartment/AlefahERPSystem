using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Common.ResponseModels
{
    public class EmployeeResponseModel
    {
        public viewEmployees Employee { get; set; }
        public viewUsers User { get; set; }
    }
}
