using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string BranchNameEN { get; set; }
        public string? BranchNameAR { get; set; }
        public string? ContactName { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactEmail { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int CountryID { get; set; }
        public int RegionID { get; set; }
        public string? ZipCode { get; set; }
        public int CityID { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }


    }
}
