using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderNameEN { get; set; }
        public string GenderNameAR { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
}
