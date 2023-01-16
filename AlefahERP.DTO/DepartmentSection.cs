using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class DepartmentSection
    {
        public int SectionID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentNameEN { get; set; }
        public string DepartmentNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
