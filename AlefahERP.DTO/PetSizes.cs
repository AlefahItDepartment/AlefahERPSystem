using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetSizes
    {
        [Key]
        public int PetSizeID { get; set; }
        public string PetSizeNameEN { get; set; }
        public string? PetSizeNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
