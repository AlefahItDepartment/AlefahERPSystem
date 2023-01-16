using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Nationality
    {
        [Key]
        public int NationlityID { get; set; }
        public string NationlityNameEN { get; set; }
        public string? NationlityNameAR { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
