using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class TestTypes
    {
        [Key]
        public int TestTypeID { get; set; }
        public string TestTypeNameEN { get; set; }
        public string? TestTypeNameAR { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
