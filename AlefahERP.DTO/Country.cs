using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string? CountryCode { get; set; }
    }
}
