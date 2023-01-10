using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Reflection;

namespace AlefahERP.DTO
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }
        public string Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Extension { get; set; }
        public string? Email { get; set; }
        public string? Nationality { get; set; }
        public int? DepartmentID { get; set; }
        public int? DesignationID { get; set; }
        public int BranchID { get; set; }
        public int UserID { get; set; }
        public string? ProfileImage { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public string? ZipCode { get; set; }
        public int? CityID { get; set; }
        public string? Location { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }


    }
}
