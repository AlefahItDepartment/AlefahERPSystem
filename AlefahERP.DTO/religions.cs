using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Religions
    {
        public int ReligionID { get; set; }
        public string ReligionNameEN { get; set; }
        public string ReligionNameAR { get;set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }

    }
