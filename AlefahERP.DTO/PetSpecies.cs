using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetSpecies
    {
        [Key]
        public int PetSpeciesID { get; set; }
        public string PetSpeciesNameEN { get; set; }
        public string? PetSpeciesNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }
    }
}
