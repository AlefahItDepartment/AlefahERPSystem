using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentNameEN { get; set; }
        public string? DepartmentNameAR { get; set; }
        public bool? IsActive { get; set; }

    }
}
