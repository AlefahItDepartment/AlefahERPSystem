using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class InsuranceType
    {
        public int InsuranceTypeID { get; set; }
        public string InsuranceTypeNameEN { get; set; }
        public string InsuranceTypeNameAR{ get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
