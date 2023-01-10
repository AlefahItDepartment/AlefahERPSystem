using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.DTO
{
    public class viewCustomersPET
    {
        public int CustomerPetID { get; set; }
        public int CustomerID { get; set; }
        public string PetName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int PetSpeciesID { get; set; }
        public string PetSpeciesNameEN { get; set; }
        public string PetSpeciesNameAR { get; set; }
        public int PetSubSpeciesID { get; set; }
        public string PetSubSpeciesNameEN { get; set; }
        public string PetSubSpeciesNameAR { get; set; }
        public int PetBreedID { get; set; }
        public string PetBreedNameEN { get; set; }
        public string PetBreedNameAR { get; set; }
        public int? PetColorID { get; set; }
        public string PetColorNameEN { get; set; }
        public string PetColorNameAR { get; set; }
        public int? PetSizeID { get; set; }
        public string PetSizeNameEN { get; set; }
        public string PetSizeNameAR { get; set; }
        public string? PetWeight { get; set; }
        public int? PetOriginID { get; set; }
        public string PetOriginNameEN { get; set; }
        public string PetOriginNameAR { get; set; }
        public string? PetImage { get; set; }
        public string PetStatus { get; set; }

    }
}
