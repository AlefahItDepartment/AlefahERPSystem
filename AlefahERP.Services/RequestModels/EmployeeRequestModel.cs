using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.RequestModels
{
    public class EmployeeRequestModel
    {
        public Employees Employee { get; set; }
        public Users User { get; set; }
        public UserRole UserRole { get; set; }
    }
}
