using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class CustomersPET
    {
        [Key]
        public int CustomerPetID { get; set; }
        public int CustomerID { get; set; }
        public string PetName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? PetSpeciesID { get; set; }
        public int? PetBreedID { get; set; }
        public int? PetColorID { get; set; }
        public int? PetSizeID { get; set; }
        public string? PetImage { get; set; }
        public string? PetStatus { get; set; }

    }
}
