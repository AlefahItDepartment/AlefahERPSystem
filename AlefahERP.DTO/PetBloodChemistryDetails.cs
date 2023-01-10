using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AlefahERP.DTO
{
    public class PetBloodChemistryDetails
    {
        [Key]
        public int PetBloodChemsDetailID { get; set; }
        public int PetBloodChemsTypeID { get; set; }
        public int PetSubSpeciesID { get; set; }
        //[Precision(18, 2)]
        public double? Low { get; set; }
        //[Precision(18, 2)]
        public double? High { get; set; }
        public bool? Ok { get; set; }
        public string? Positive { get; set; }

    }
}
