using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class ContractType
    {
        public int ContractTypeID { get; set; }
        public string ContractTypeNameEN { get; set; }
        public string ContractTypeNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
