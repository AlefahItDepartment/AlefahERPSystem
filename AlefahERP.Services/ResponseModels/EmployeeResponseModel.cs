using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.ResponseModels
{
    public class EmployeeResponseModel
    {
        public viewEmployees Employee { get; set; }
        public viewUsers User { get; set; }
    }
}
