
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetSubSpecies
    {
        [Key]
        public int PetSpeciesID { get; set; }
        public string PetSubSpeciesNameEN { get; set; }
        public string? PetSubSpeciesNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }
        public int PetSubSpeciesID { get; set; }

    }
}
