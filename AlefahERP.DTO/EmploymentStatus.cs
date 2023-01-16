
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmployementStatus
    {
        public int EmploymentStatusID { get; set; }
        public string EmploymentStatusNameEN { get; set; }
        public string employmentStatusNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
