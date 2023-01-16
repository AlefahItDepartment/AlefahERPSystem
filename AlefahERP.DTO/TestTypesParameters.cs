using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class TestTypesParameters
    {
        [Key]
        public int TestTypeParameterID { get; set; }
        public int TestTypeID { get; set; }
        public int DeviceID { get; set; }
        public int LabTesstUnitID { get; set; }
        public string TestTypeParameterNameEN { get; set; }
        public string? TestTypeParameterNameAR { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
