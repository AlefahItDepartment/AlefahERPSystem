using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmployeesEmployments
    {
        [Key]
        public int EmploymentID { get; set; }
        public int EmployeeID { get; set; }
        public int BranchID { get; set; }
        public int? ProjectID { get; set; }
        public int? DepartmentID { get; set; }
        public int? SectionID { get; set; }
        public int? DesignationID { get; set; }
        public int? EmploymentCategoryID { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public int? ContractTypeID { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public int? EmploymentStatusID { get; set; }
        public int? ReportToEmployeeID { get; set; }
        public int UserRoleID { get; set; }

    }
}
