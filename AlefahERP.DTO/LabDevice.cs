using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class LabDevice
    {
        [Key]
        public int DeviceID { get; set; }
        public string DeviceNameEN { get; set; }
        public string? DeviceNameAR { get; set;}
        public int? SorrtOrder { get; set; }
        public bool? IsActive { get; set; }

    }
}
