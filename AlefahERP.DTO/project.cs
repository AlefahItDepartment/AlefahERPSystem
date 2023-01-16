using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectNameEN { get; set; }
        public string? ProjectNameAR { get; set; }
        public int? SortOrder{ get; set; }
        public bool? IsActive{ get; set; }

    }
}
