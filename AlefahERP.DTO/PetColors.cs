using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetColors
    {
        [Key]
        public int PetColorID { get; set; }
        public string PetColorNameEN { get; set; }
        public string? PetColorNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
