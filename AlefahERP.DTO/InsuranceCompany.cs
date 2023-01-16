using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class InsuranceCompany
    {
        [Key]
        public int InsuranceCompanyID { get; set; }
        public string InsuranceCompanyNameEN { get; set; }
        public string? InsuranceCompanyNameAR { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
