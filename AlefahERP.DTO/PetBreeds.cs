using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetBreeds
    {
        [Key]
        public int PetBreedID { get; set; }
        public int PetSpeciesID { get; set; }
        public string PetBreedNameEN { get; set; }
        public string? PetBreedNameAR { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

    }
}
