using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Project
    {
        public int Projects { get; set; }
        public string ProjectNameEN { get; set; }
        public string ProjectNameAR { get; set; }
        public int SortOrder{ get; set; }
        public bool IsActive{ get; set; }

    }
}
