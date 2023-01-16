using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class LabTestUnits
    {
        [Key]
        public int LabTestUnitID { get; set; }
        public string LabTestUnitNameEN { get; set; }
        public string? LabTestUnitNameAR { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
