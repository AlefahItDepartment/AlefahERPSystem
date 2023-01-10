using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string? CityCode { get; set; }
        public int RegionID { get; set; }
        public int CountryID { get; set; }

    }
}
