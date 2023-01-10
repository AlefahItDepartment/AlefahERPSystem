using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class CultureCodes
    {
        [Key]
        public int CultureCodeID { get; set; }
        public int CultureKey { get; set; }
        public string CultureValue { get; set; }
        public string CultureCode { get; set; }

    }
}
