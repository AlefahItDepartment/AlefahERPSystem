using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace AlefahERP.DTO
{
    public class CustomersAddressLines
    {
        [Key]
        public int AddressID { get; set; }
        public int? AddressLineTypeID { get; set; }
        public int? CustomerID { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public string? ZipCode { get; set; }
        public int? CityID { get; set; }
        public string? Location { get; set; }
        public bool? IsDefault { get; set; }
    }
}
