using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class ServiceDetails
    {
        [Key]
        public int ServiceDetailID { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceDetailNameEN { get; set; }
        public string ServiceDetailNameAR { get; set; }
        [Precision(18, 2)]
        public decimal? UnitPrice { get; set; }
        [Precision(18, 2)]
        public decimal? ServiceUnitPrice { get; set; }
        public bool? IsActive { get; set; }

    }
}
