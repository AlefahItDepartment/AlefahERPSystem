using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class Employees1
    {
        [Key]
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int GenderID { get; set; }
        public int? NationalityID { get; set; }
        public string NationalID { get; set; }
        public DateTime NationalIDExpiry { get; set; }
        public string? PassportID { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string Mobile { get; set; }
        public string? Email { get; set; }
        public int? QualificationID { get; set; }
        public int? SpecializationID { get; set; }
        public int? ReligionID { get; set; }
        public string? Comments { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

    }
}
