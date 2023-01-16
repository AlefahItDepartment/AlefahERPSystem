using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmploymentCategory
    {

        public int EmploymentCategoryID { get; set; }
        public string EmploymentCategoryNameEN { get; set; }
        public string EmploymentCategoryNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
