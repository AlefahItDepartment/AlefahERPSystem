using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class EmployeesAddress
    {
        [Key]
        public int EmployeeAddressID { get; set; }
        public int EmployeeID { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public string? ZipCode { get; set; }
        public int? CityID { get; set; }
        public string? HomeAddressLine1 { get; set; }
        public string? HomeAddressLine2 { get; set; }
        public int? HomeCountryID { get; set; }
        public int? HomeRegionID { get; set; }
        public string? HomeZipCode { get; set; }
        public int? HomeCityID { get; set; }

    }
}
