using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetBloodChemistryTypes
    {
        [Key]
        public int PetBloodChemsTypeID { get; set; }
        public string PetBloodChemsTypeNameEN { get; set; }
        public string? PetBloodChemsTypeNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
