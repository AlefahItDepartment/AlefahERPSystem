using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeID { get; set; }
        public string ServiceTypeNameEN { get; set; }
        public string? ServiceTypeNameAR { get; set; }
        public string? ServiceTypeImage { get; set; }
        public bool? IsActive { get; set; }

    }
}
