using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetOrigins
    {
        [Key]
        public int PetOriginID { get; set; }
        public string PetOriginNameEN { get; set; }
        public string? PetOriginNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
