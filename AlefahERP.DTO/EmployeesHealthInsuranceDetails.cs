using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmployeesHealthInsuranceDetails
    {
        [Key]
        public int EmployeeHealthInsuranceID { get; set; }
        public int EmployeeID { get; set; }
        public int InsuranceCompanyID { get; set; }
        public int InsuranceTypeID { get; set; }
        public int InsuranceStartDate { get; set; }
        public int InsuranceEndDate { get; set; }
    }
}
