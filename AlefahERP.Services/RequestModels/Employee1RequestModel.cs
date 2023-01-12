using AlefahERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Services.RequestModels
{
    public class Employee1RequestModel
    {
        public Employees1 Employees1 { get; set; }
        public string? UploadEmployeePicture { get; set; }
        public EmployeesPictures? EmployeesPictures { get; set; }
        public EmployeesAddress? EmployeesAddress { get; set; }
        public EmployeesEmployments? EmployeesEmployments { get; set; }
        public EmployeesHealthInsuranceDetails? EmployeesHealthInsuranceDetails { get; set; }
        public List<EmployeesAttachments>? EmployeesAttachments { get; set; }
    }
}
