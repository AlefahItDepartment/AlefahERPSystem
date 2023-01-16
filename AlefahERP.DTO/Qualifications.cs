using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Qualifications
    {
        public int QualificationID { get; set; }
        public string QualificationNameEN { get; set; }
        public string QualificationNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
