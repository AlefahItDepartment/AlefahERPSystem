using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }
        public string DesignationNameEN { get; set; }
        public string? DesignationNameAR { get; set; }
        public bool? IsActive { get; set; }

    }
}
