using System.Reflection.Emit;

namespace AlefahERP.DTO
{
    public class viewCustomerAddressLines
    {
        public int AddressID { get; set; }
        public int AddressLineTypeID { get; set; }
        public string AddressLineTypeName { get; set; }
        public int CustomerID { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public int? RegionID { get; set; }
        public string? RegionName { get; set; }
        public string? RegionCode { get; set; }
        public string? ZipCode { get; set; }
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }
        public string? Location { get; set; }
        public bool? IsDefault { get; set; }

    }
}
