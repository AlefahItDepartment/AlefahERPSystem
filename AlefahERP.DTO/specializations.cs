using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Specializations
    {
        public int SpecializationID { get; set; }
        public int QualificationID { get; set; }
        public string SpecializationNameEN { get; set; }
        public string SpecializationNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set;}

    }
}
