using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetExamineTypes
    {
        [Key]
        public int PetExamineTypeID { get; set; }
        public string PetExamineTypeNameEN { get; set; }
        public string? PetExamineTypeNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
