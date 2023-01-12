using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmployeesPictures
    {
        [Key]
        public int EmployeePictureID { get; set; }
        public int EmployeeID { get; set; }
        public byte[]? EmployeePictureData { get; set; }
        public bool? IsDefault { get; set; }
    }
}
