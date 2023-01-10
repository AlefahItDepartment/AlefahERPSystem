using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public string? RegionCode { get; set; }
        public int CountryID { get; set; }
    }
}
